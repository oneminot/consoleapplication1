using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void doit()
        {
            for (UInt64 i = 0; i < UInt64.MaxValue; i++)
            {
                double x = Math.Sqrt(Math.PI);
                Console.WriteLine(x);
                Random r = new Random();
                Console.WriteLine(r);
                Console.WriteLine("Hello, world...");
                string urlAddress = "https://etbumath.appspot.com";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();
                }
            }
        }
        static void A()
        {
            System.Threading.Thread.Sleep(5);
            Console.WriteLine('A');
            doit();
        }

        static void B()
        {
            System.Threading.Thread.Sleep(12);
            Console.WriteLine('B');
            doit();
        }
        static void Main(string[] args)
        {
            for (UInt64 i = 0; i < UInt64.MaxValue; i++)
            {
                A(); B();
            }
            Console.ReadKey();
        }
    }
}
