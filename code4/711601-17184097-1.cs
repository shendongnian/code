    public static CookieContainer Login()
    {
      CookieContainer container;
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(login);
      req.Method = "POST";
      req.ContentType = "application/x-www-form-urlencoded";
      byte[] postbuf = Encoding.ASCII.GetBytes(loginQuery);
      req.ContentLength = postbuf.Length;
      Stream rs = req.GetRequestStream();
      rs.Write(postbuf, 0, postbuf.Length);
      rs.Close();
      container = req.CookieContainer = new CookieContainer();
      WebResponse resp = req.GetResponse();
      resp.Close();
      return container;
    }
