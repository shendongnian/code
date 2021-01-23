    ...
    cts = new CancellationTokenSource();
    string result;
    using (var client = new HttpClient())
    using (var response = await client.GetAsync("http://gyorgybalassy.wordpress.com", cts.Token))
    {
      result = await response.Content.ReadAsStringAsync();
    }
    if (result.Length < 100000)
    ...
