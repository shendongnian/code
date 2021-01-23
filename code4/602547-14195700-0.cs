    public async Task<string> CheckAvailability()
    {
        var webClient = new WebClient();
        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        var result = await webClient.UploadStringTaskAsync(new Uri("http://random.php"), "?lookup=10");
        return result;
    }
