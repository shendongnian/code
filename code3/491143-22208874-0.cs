    string fileText;
    using (var memoryStream = new MemoryStream())
    {
        cloudBlob.DownloadToStream(memoryStream);
        memoryStream.Position = 0;
                    
        using (var reader = new StreamReader(memoryStream, Encoding.Unicode))
        {
            fileText = reader.ReadToEnd();
        }
    }
