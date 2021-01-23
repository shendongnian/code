    public class CookieAwareWebClient : WebClient
    {
        private CookieContainer cookie = new CookieContainer();
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = cookie;
            }
            return request;
        }
    }
