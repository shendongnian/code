    public static Task<string> Post(string url, string data, string authToken) {
        var client = new WebClient { Encoding = Encoding.UTF8 };
        client.Headers.Add("Content-Type:application/x-www-form-urlencoded");
        client.Headers.Add(AuthHeader(authToken));
        return client.UploadStringTaskAsync(new Uri(url), "POST", data);
    }
