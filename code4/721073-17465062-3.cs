    public Download(Request request)
    {
        try {
            var image = GetImageFromCache(request.Url);
            if (image == null) {
                image = DownloadImageFromServer(request.Url); // Could be synchronous
            }
            request.OnDownload(image);
        } catch (Exception e) {
            request.OnError(e);
        }
    }
