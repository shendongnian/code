    private HttpWebRequest CreateRequest(string url, string method, string sessionCookie)
    {
      if (string.IsNullOrEmpty(url))
        throw new ArgumentException("Empty value", "url");
      HttpWebRequest result = WebRequest.Create(url) as HttpWebRequest;
      if (result == null)
        throw new ArgumentException("Only the HTTP protocol is supported", "url");
      result.CookieContainer = new CookieContainer();
      if (sessionCookie != null) {
        result.CookieContainer.Add(
          new Uri(url), 
          new Cookie(SessionCookieName, sessionCookie)
        );
      }
      result.Method = method;
      return result;
    } // CreateRequest
