    /// <summary>
    /// A custom WebClient featuring a cookie container
    /// </summary>
    public class WebClientEx : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }
        public WebClientEx()
        {
            CookieContainer = new CookieContainer();
        }
        protected override WebRequest GetWebRequest( Uri address )
        {
            var request = base.GetWebRequest( address );
            if ( request is HttpWebRequest )
            {
                ( request as HttpWebRequest ).CookieContainer = CookieContainer;
            }
            return request;
        }
    }
