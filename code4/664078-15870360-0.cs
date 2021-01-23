    public void GetString(string url, Action<string> onCompletion = null)
    {
        WebClient client = new WebClient();
        client.DownloadStringCompleted += (s, e) =>
            {
                if (onCompletion != null)
                    onCompletion(e.Result);
            };
        client.DownloadStringAsync(new Uri(url));
    }
