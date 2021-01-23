    public static async Task<string> DownloadStringTaskAsync(this WebClient webClient, string url, CancellationToken cancellationToken) {
        using (cancellationToken.Register(webClient.CancelAsync)) {
            return await webClient.DownloadStringTaskAsync(url);
        }
    }
    public static async Task<string> DownloadStringTaskAsync(this WebClient webClient, Uri uri, CancellationToken cancellationToken) {
        using (cancellationToken.Register(webClient.CancelAsync)) {
            return await webClient.DownloadStringTaskAsync(uri);
        }
    }
