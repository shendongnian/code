    public void Configure()
    {
        var data = "my data";
        Task.Run(() => NotifyApi(data));
    }
    
    private async Task NotifyApi(bool data)
    {
        var toSend = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        await client.PostAsync("http://...", data);
    }
