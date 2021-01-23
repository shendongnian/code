    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;
    using System.Web;
    using System.Net;
    using System.IO;
    
    namespace ConsoleProgram
    {
        public class Class1
        {
            private const string URL = "https://sub.domain.com/objects.json?api_key=123";
            private const string DATA = @"{""object"":{""name"":""Name""}}";
    
            static void Main(string[] args)
            {
                Class1.CreateObject();
            }
    
            private static void CreateObject()
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(DATA);
                }
    
                try
                {
                    WebResponse webResponse = request.GetResponse();
                    using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        Console.Out.WriteLine(response);
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("-----------------");
                    Console.Out.WriteLine(e.Message);
                }
    
            }
        }
    }
