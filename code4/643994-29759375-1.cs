    public static string GetIpAddress()
    {
      var request = HttpContext.Current.Request;
      // Look for a proxy address first
      var ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
      // If there is no proxy, get the standard remote address
      if (string.IsNullOrWhiteSpace(ip)
          || string.Equals(ip, "unknown", StringComparison.OrdinalIgnoreCase))
        ip = request.ServerVariables["REMOTE_ADDR"];
      else
      {
        //extract first IP
        var index = ip.IndexOf(',');
        if (index > 0)
          ip = ip.Substring(0, index);
        //remove port
        index = ip.IndexOf(':');
        if (index > 0)
          ip = ip.Substring(0, index);
      }
      return ip;
    }
