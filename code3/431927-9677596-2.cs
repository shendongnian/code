    ulong memoryKilobytes =
        GetAvailableMemoryKilobytes();
        // ...or GetTotalMemoryKilobytes();
    int bufferSize = GetBufferSize(memoryKilobytes);
    
    using (FileStream TheFileStream = new FileStream(FilePath.Text, FileMode.Open))
    {
        byte[] FileArray = new byte[bufferSize];
        int readCount;
    
        while ((readCount = TheFileBinary.Read(FileArray, 0, bufferSize)) > 0)
        {
            // Call a method here, passing FileArray as a parameter
        }
    }
