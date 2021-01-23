    static bool RemoteFileExists(string url)
    {
      try
      {
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        request.Method = "HEAD";
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        response.Close();
        return (response.StatusCode == HttpStatusCode.OK);
      }
      catch
      {
        return false;
      }
    }
