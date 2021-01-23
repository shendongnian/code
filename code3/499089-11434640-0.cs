    private static string GetStatusCode(string url)
    {
          HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
          req.Method = WebRequestMethods.Http.Get;
          req.ProtocolVersion = HttpVersion.Version11;
          req.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";
    
          try
          {
             HttpWebResponse response = (HttpWebResponse)req.GetResponse();
             StringBuilder sb = new StringBuilder();
    
             foreach (string header in response.Headers)
             {
                sb.AppendLine(string.Format("{0}: {1}", header, response.GetResponseHeader(header)));
             }
    
             return string.Format("Response Status Code: {0}\nServer:{1}\nProtocol: {2}\nRequest Method: {3}\n\n***Headers***\n\n{4}", response.StatusCode,response.Server, response.ProtocolVersion, response.Method, sb);
           }
           catch (Exception e)
           {
              return string.Format("Error: {0}", e.ToString());
           }
    }
