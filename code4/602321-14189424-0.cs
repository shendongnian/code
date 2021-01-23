    webClient.DownloadFileCompleted += (o, s) =>
    {
        if (File.Exists(mapPathName))
           File.Delete(mapPathName);
    };
    webClient.DownloadFile(uri, mapPathName);
    webClient.Dispose();
