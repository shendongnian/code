    try
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.goo4le.com/");
        request.Method = "HEAD";
        request.AllowAutoRedirect = false;
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
      Console.Write((int)response.StatusCode);
    }
    }
    catch (WebException e)
    {
       // in this case it was a status code exception (not status 200...)
       if (e.Response != null) Console.Write((int)e.Response.StatusCode);
       throw;
    }
