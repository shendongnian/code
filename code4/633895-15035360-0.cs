        public class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var req = base.GetWebRequest(address) as HttpWebRequest;
                req.AutomaticDecompression = DecompressionMethods.GZip;
                return req;
            }
        }
