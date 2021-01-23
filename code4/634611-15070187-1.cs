    //Controller entry point.
    public async Task<HttpResponseMessage> PostAsync()
    {
      using (var client = new HttpClient())
      {
        var request = BuildRelayHttpRequest(this.Request);
        //HttpCompletionOption.ResponseHeadersRead - so that I can start streaming the response as soon
        //As it begins to filter in.
        var relayResult = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        var returnMessage = BuildResponse(relayResult);
        return returnMessage;
      }
    }
