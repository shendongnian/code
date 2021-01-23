    public async static Task<Uri> VerifyFtpAsync(IPAddress ip)
    {
      try
      {
        ...
        return serverUri;
      }
      catch (WebException)
      {
        return null;
      }
    }
    ...
    var ipTasks = ips.Select(ip => VerifyFtpAsync(ip));
    var allResults = await Task.WhenAll(ipTasks);
    var result = allResults.Where(url => url != null).ToArray();
