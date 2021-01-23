    // If a non-base64 string is passed as value, the result will
    // be same as the passed value
    string result = value;
    if (!string.IsNullOrEmpty(value))
    {
      var bytes = HttpServerUtility.UrlTokenDecode(value);
      if (bytes != null) {
        result = System.Text.Encoding.UTF8.GetString(bytes);
      }
    }
    return result;
