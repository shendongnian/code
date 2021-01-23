    delegate void BeginUploadFinished(IAsyncResult result);
    public void UploadFile()
    {
        //Initial configuration
        var account = CloudStorageAccount.DevelopmentStorageAccount;
        var client = account.CreateCloudBlobClient();
        var container = client.GetContainerReference("myfiles");
        Stream stream = new MemoryStream();
        var state = new Object{};
        
        //Upload to azure
        var blob = container.GetBlobReference("test.txt");
        BeginUploadFinished beginUploadFinished = delegate(IAsyncResult result)
        {
            blob.EndUploadFromStream(result);
            Trace.WriteLine("EndUploadFromStream", "Information");
            stream.Close();
            stream.Dispose();
        };
        //Write to stream
        Trace.WriteLine("Writing Stream", "Information");
        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j < 50; j++)
            {
                stream.WriteByte(65);
            }
        }
        stream.Seek(0, SeekOrigin.Begin);
        Trace.WriteLine("BeginUploadFromStream", "Information");
        var _result =  blob.BeginUploadFromStream(stream, new AsyncCallback(beginUploadFinished), state);
        _result.AsyncWaitHandle.WaitOne();
    }
