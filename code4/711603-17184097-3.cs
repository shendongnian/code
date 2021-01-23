    public class CookieAwareWebClient : WebClient
    {
      public void Login(string loginPageAddress, NameValueCollection loginData)
      {
        CookieContainer container;
    
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(loginPageAddress);
    
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] postbuf = Encoding.ASCII.GetBytes(loginData.ToString());
        req.ContentLength = postbuf.Length;
        Stream rs = req.GetRequestStream();
        rs.Write(postbuf, 0, postbuf.Length);
        rs.Close();
    
        container = req.CookieContainer = new CookieContainer();
    
        WebResponse resp = req.GetResponse();
        resp.Close();
        CookieContainer = container;
      }
    
      public CookieAwareWebClient(CookieContainer container)
      {
        CookieContainer = container;
      }
      public CookieAwareWebClient()
        : this(new CookieContainer())
      {
      }
      public CookieContainer CookieContainer { get; private set; }
    
      protected override WebRequest GetWebRequest(Uri address)
      {
        var request = (HttpWebRequest)base.GetWebRequest(address);
        request.CookieContainer = CookieContainer;
        return request;
      }
    }
