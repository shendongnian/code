    WebClient client = new WebClient();
    client.Encoding = System.Text.Encoding.UTF8;
    Uri update = new Uri(uri);
    client.DownloadFileAsync(update, "update.exe");
    client.DownloadProgressChanged +=new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
