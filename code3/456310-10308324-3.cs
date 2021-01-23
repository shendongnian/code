    static WebResponse SendNamedStrings(string url, Dictionary<string, string> namedStrings)
    {
      string postData = "?" + string.Join("&", namedStrings.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)));
    
      WebRequest request = WebRequest.Create(url);
      request.Method = "POST";
      byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
      request.ContentType = "application/x-www-form-urlencoded";
      request.ContentLength = byteArray.Length;
      Stream dataStream = request.GetRequestStream();
      dataStream.Write(byteArray, 0, byteArray.Length);
      dataStream.Close();
    
      return request.GetResponse();
    }
