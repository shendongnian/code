    long offset = 0x10000000; // 256 megabytes 
    long length = 100; 
    using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(@"c:\Test.data"))
        {
            using (MemoryMappedViewStream stream = CreateViewStream(offset, length))
            {
                byte[length] bytes;
                int bytesRead = stream.Read(bytes, 0, (int)length);
            }
        }
