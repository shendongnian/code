    string result = value;
    if (!string.IsNullOrEmpty(value))
    {
      var bytes = System.Text.Encoding.UTF8.GetBytes(value);
      result = HttpServerUtility.UrlTokenEncode(bytes);
    }
    return result;
    
