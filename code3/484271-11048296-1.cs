    using (var stream = File.Open(dumpPath, FileMode.Open))
    {
        var files = new[] 
        {
            new UploadFile
            {
                Name = "file",
                Filename = Path.GetFileName(dumpPath),
                ContentType = "text/plain",
                Stream = stream
            }
        };
        var values = new NameValueCollection
        {
            { "client", "VIP" },
            { "name", "John Doe" },
        };
        
        byte[] result = UploadFiles(address, files, values);
    }
