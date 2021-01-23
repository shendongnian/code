    const string toCompress = @"input.file";
    var buffer = new byte[1024*1024*64];
           
    using(var compressing = new GZipStream(File.OpenWrite(@"output.gz"), CompressionMode.Compress))
    using(var file = File.OpenRead(toCompress))
    {
        var bytesRead = 0;
        while(bytesRead < buffer.Length)
        {
            bytesRead = file.Read(buffer, 0, buffer.Length);
            compressing.Write(buffer, 0, buffer.Length);
        }
    }
