    using System;
    using System.IO;
    using System.Net;
    class Program
    {
        static void Main()
        {
            var url = "http://links.casemakerlegal.com/states/MS/books/Case_Law/results?search[Cite]=77%20So.3d%201094";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                Console.WriteLine(result);
            }
        }
    }
