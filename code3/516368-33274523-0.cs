    var mergedCredentials = string.Format("{0}:{1}", username, password);
    var byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
    var encodedCredentials = Convert.ToBase64String(byteCredentials);
    using (WebClient webClient = new WebClient())
    {
        webClient.Headers.Set("Authorization", "Basic " + encodedCredentials);
        return webClient.DownloadString(url);
    }
