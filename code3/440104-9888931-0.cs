    #region webclient with cookies
    public class WebClientX : WebClient
    {
        public CookieContainer cookies = new CookieContainer();
        protected override WebRequest GetWebRequest(Uri location)
        {
            WebRequest req = base.GetWebRequest(location);
            if (req is HttpWebRequest)
                (req as HttpWebRequest).CookieContainer = cookies;
            return req;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse res = base.GetWebResponse(request);
            if (res is HttpWebResponse)
                cookies.Add((res as HttpWebResponse).Cookies);
            return res;
        }
    }
    #endregion
