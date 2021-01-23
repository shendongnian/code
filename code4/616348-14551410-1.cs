            CookieContainer cookieJar = new CookieContainer();
            cookieJar.Add(new Cookie("my_cookie", "cookie_value", "/", "mysite"));
            CookieAwareWebClient client = new CookieAwareWebClient(cookieJar);
            string response = client.DownloadString("http://mysite.com/response_with_cookie_only.php");
---
    public class CookieAwareWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; set; }
        public Uri Uri { get; set; }
    
        public CookieAwareWebClient()
            : this(new CookieContainer())
        {
        }
    
        public CookieAwareWebClient(CookieContainer cookies)
        {
            this.CookieContainer = cookies;
        }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = this.CookieContainer;
            }
            HttpWebRequest httpRequest = (HttpWebRequest)request;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return httpRequest;
        }
    
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];
    
            if (setCookieHeader != null)
            {
                //do something if needed to parse out the cookie.
                if (setCookieHeader != null)
                {
                    Cookie cookie = new Cookie(); //create cookie
                    this.CookieContainer.Add(cookie);
                }
            }
            return response;
        }
    }
