    using (var client = new WebClient())
    {
      try
      {
        client.DownloadFile(url, destination);
      }
      catch (WebException wex)
      {
        if (((HttpWebResponse) wex.Response).StatusCode == HttpStatusCode.NotFound)
        {
          // error 404, do what you need to do
        }
      }
    }
