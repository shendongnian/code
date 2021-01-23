    public class HTTP : WebClient
    {
        public HTTP()
            : this(new CookieContainer())
        { }
        public HTTP(CookieContainer c)
        {
            CookieContainer = c;
        }
        public CookieContainer CookieContainer { get; set; }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            var castRequest = request as HttpWebRequest;
            if (castRequest != null)
            {
                castRequest.CookieContainer = CookieContainer;
                castRequest.ServicePoint.Expect100Continue = false;
                castRequest.ContentType = "application/x-www-form-urlencoded";
            }
            return request;
        }
    }
