    private static async Task<byte[]> downloadDataAsync(Uri uri, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(uri.ToString()))
            throw new ArgumentNullException(nameof(uri), "Uri can not be null or empty.");
        if (!Uri.IsWellFormedUriString(uri.ToString(), UriKind.Absolute))
            return null;
        byte[] dataArr = null;
        try
        {
            using (var webClient = new WebClient())
            using (var registration = cancellationToken.Register(() => webClient.CancelAsync()))
            {
                dataArr = await webClient.DownloadDataTaskAsync(uri);
            }
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.RequestCanceled)
        {
            // ignore this exception
        }
        return dataArr;
    }
