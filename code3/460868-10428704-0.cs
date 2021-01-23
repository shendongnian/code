    Dictionary<string,string> headers = new Dictionary<string,string>();
    using(Stream stream = System.IO.File.OpenRead(localFilePath))
    {
        obj.Write(stream, headers);
    }
