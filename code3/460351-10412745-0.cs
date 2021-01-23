    using System;
    using System.Net;
    using System.Xml;
    
    namespace Shelver
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebRequest requ = WebRequest.Create("http://www.globalgear.com.au/productfeed.xml");
                requ.Timeout = 10 * 60 * 1000; // 10 minutes timeout and not 100s as the default.
                var resp = requ.GetResponse();
    
                Console.WriteLine("Will download {0:N0}bytes", resp.ContentLength);
                var stream = resp.GetResponseStream();
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);
    
            }
        }
    }
