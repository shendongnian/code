    public void CheckAvailability(Action<Exception, string> callback)
    {
        var webClient = new WebClient();
        webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        webClient.UploadStringCompleted += (s,e) => callback(e.Error, e.Result);
        wc.UploadStringAsync(new Uri("http://random.php"), "?lookup=10");
    }
