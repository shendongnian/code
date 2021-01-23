    public static JObject WebRequest(string url) {
        var client = new WebClient();
        client.Headers.Add("User-Agent", "Nobody");
        var response = client.DownloadString(new Uri(url));
        var responsestring = response.ToString();
        return JObject.Parse(responsestring);
    }
