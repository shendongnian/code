    // Since this method is an async method, it will return as
    // soon as it hits an await statement.
    public async void MyMethod()
    {
        HttpClient client = new HttpClient();
        // Using the async keyword, anything within this method
        // will wait until after client.GetAsync returns.
        HttpResponseMessage responseMsg = await client.GetAsync(requesturl).Result;
        responseMsg.EnsureSuccessStatusCode();
        Task<string> responseBody = responseMsg.Content.ReadAsStringAsync(); 
    }
