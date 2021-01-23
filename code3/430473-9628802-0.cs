    using System;
    using System.IO;
    using System.Net;
    namespace SO9628006
    {
        class Program
        {
            static void Main()
            {
                var request = (HttpWebRequest)WebRequest.Create("http://www.fiddler2.com/Fiddler/Fiddler.css");
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var etag = response.Headers.Get("ETag");
                Console.WriteLine(etag);
            }
        }
    }
