    public class CookieAwareWebClient : WebClient
    {
        private CookieContainer cookie = new CookieContainer();
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            //WebRequest request = base.GetWebRequest(address);
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            //request.ProtocolVersion = HttpVersion.Version10;
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = cookie;
            }
            return request;
        }
    }
