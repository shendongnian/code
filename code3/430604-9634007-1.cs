    String f1Path = @"C:\Temp\Test1.txt";
    String f2Path = @"C:\Temp\Test2.txt";
    byte[] buffer;
    int offset;
    int length;
 
    using (FileStream f1ReadStream = new FileStream(f1Path, FileMode.Open, FileAccess.Read))
    {
        offset = (int)f1ReadStream.Length;
    }
    using (FileStream f2ReadStream = new FileStream(f2Path, FileMode.Open, FileAccess.Read))
    {
        length = (int)f2ReadStream.Length;
    }
    // read file2 and append all to file1
    using (var mappedFile2 = MemoryMappedFile.CreateFromFile(f2Path, FileMode.Open, null,  length))
    {
        using (var reader = mappedFile2.CreateViewStream(0, length, MemoryMappedFileAccess.Read))
        {
            // Read from MMF
            buffer = new byte[length];
            reader.Read(buffer, 0, length);
        }
    }
    using (var mappedFile1 = MemoryMappedFile.CreateFromFile(f1Path,FileMode.Open, null, offset + length))
    {
        // Create writer to MMF
        using (var writer = mappedFile1.CreateViewAccessor(offset, length, MemoryMappedFileAccess.Write))
        {
            // Write to MMF
            writer.WriteArray<byte>(0, buffer, 0, length);
        }
    }
