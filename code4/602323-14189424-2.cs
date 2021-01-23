    webClient.DownloadFileCompleted += (o, s) =>
    {
        //if (File.Exists(mapPathName)) discard, see Paolo's comments below . . .
           File.Delete(mapPathName);
    };
    webClient.DownloadFileAsync(uri, mapPathName);
    webClient.Dispose();
