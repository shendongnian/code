    List<byte> byteArr = new List<byte>();
    byte[] buffer = new byte[1024];
    int bytesRead = 1;
    using(FileStream TheFileStream = new FileStream(FilePath.Text, FileMode.Open))
    {
        while(bytesRead > 0)
        {
            bytesRead = TheFileStream.Read(buffer, 0, 1024);
            byteArr.AddRange(buffer);
        }
    }
    buffer = byteArr.ToArray();
    // call your method here.
