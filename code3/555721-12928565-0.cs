    private long _uploadedByteCount;
    void SomeMethod()
    {
        using (Stream output = File.OpenWrite("c:\temp\file.zip"))
        using (Stream input = file.InputStream)
        {
            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
                Interlocked.Add(ref _uploadedByteCount, bytesRead);
            }
        }
    }
    public long GetUploadedByteCount()
    {
        return _uploadedByteCount;
    }
