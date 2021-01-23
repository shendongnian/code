    byte[] bytes;
    public void DownloadFile()
    {
        WebClient webClient = new WebClient();
        webClient.OpenReadCompleted += (s, e) =>
           {
               Stream stream = e.Result;
               MemoryStream ms = new MemoryStream();
               stream.CopyTo(ms);
               bytes = ms.ToArray();
           };
        webClient.OpenReadAsync(new Uri("http://myurl.com/file.zip"), UriKind.Absolute);
    }
