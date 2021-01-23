    public async Task<HttpResponseMessage> Post<T>(string requestUri, T newObject) where T : class
    {
      using (var client = new HttpClient())
      {
         client.BaseAddress = this.HttpClientAddress;
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         var content = JsonConvert.SerializeObject(newObject, this.JsonSerializerSettings);
         var clientAsync = await client.PostAsync(requestUri, new StringContent(content, Encoding.UTF8, "application/json"));
         clientAsync.EnsureSuccessStatusCode();
    
         return clientAsync;
       }
    }
