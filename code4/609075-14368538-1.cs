    var writer = new ActionBlock<string>(async url =>
    {
        WebClient wc = new WebClient();
        // using IOCP the thread pool worker thread does return to the pool
        byte[] buffer = await wc.DownloadDataTaskAsync(url);
        string fileName = Path.GetFileName(url);
     
        string name = @"Images\" + fileName;
     
        using (Stream srm = File.OpenWrite(name))
        {
            await srm.WriteAsync(buffer, 0, buffer.Length);
        }
    });
