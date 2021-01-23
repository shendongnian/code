    using System;
    using System.Net;
    
    class Test
    {
        static void Main()
        {
            string url = "http://tinyurl.com/so-hints";
            Console.WriteLine(LengthenUrl(url));
        }
        
        static string LengthenUrl(string url)
        {
            var request = WebRequest.CreateHttp(url);
            request.AllowAutoRedirect = false;
            using (var response = request.GetResponse())
            {
                var status = ((HttpWebResponse) response).StatusCode;
                if (status == HttpStatusCode.Moved ||
                    status == HttpStatusCode.MovedPermanently)
                {
                    return response.Headers["Location"];
                }
                // TODO: Work out a better exception
                throw new Exception("No redirect required.");
            }
        }
    }
