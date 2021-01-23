    string url = "https://site.com";
    using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
    {
      var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
      var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
      ...
