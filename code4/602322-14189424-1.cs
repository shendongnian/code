    webClient.DownloadFileCompleted += (o, s) =>
    {
        if (File.Exists(mapPathName))
           File.Delete(mapPathName);
    };
    webClient.DownloadFileAsync(uri, mapPathName);
    webClient.Dispose();
