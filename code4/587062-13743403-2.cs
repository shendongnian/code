    public class MyWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }
        public MyWebClient()
        {
            this.CookieContainer = new CookieContainer();
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = this.CookieContainer;
                (request as HttpWebRequest).AllowAutoRedirect = true;
            }
            return request;
        }
    }
