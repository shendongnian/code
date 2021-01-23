    NameValueCollection queryParameters = new NameValueCollection();
    string[] querySegments = queryString.Split('&');
    foreach(string segment in querySegments)
    {
       string[] parts = segment.Split('=');
       if (parts.Length > 0)
       {
          string key = parts[0].Trim(new char[] { '?', ' ' });
          string val = parts[1].Trim();
    
          queryParameters.Add(key, val);
       }
    }
