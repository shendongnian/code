    public static void Insert(string filepath, int insertOffset, Stream dataToInsert)
    {
        var newFilePath = filepath + ".tmp";
        using (var source = File.OpenRead(filepath))
        using (var destination = File.OpenWrite(newFilePath))
        {
            CopyTo(source, destination, insertOffset);// first copy the data before insert
            dataToInsert.CopyTo(destination);// write data that needs to be inserted:
            CopyTo(source, destination, (int)(source.Length - insertOffset)); // copy remaining data
        }
    
        // delete old file and rename new one:
        File.Delete(filepath);
        File.Move(newFilePath, filepath);
    }
   
    private static void CopyTo(Stream source, Stream destination, int count)
    {
        const int bufferSize = 32 * 1024;
        var buffer = new byte[bufferSize];
    
        var remaining = count;
        while (remaining > 0)
        {
            var toCopy = remaining > bufferSize ? bufferSize : remaining;
            var actualRead = source.Read(buffer, 0, toCopy);
    
            destination.Write(buffer, 0, actualRead);
            remaining -= actualRead;
        }
    }
