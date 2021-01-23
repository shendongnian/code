    public class CookieWebClient : WebClient
    {
        private readonly CookieContainer _cookies = new CookieContainer();
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.CookieContainer = _cookies;
            }
            return request;
        }
    }
