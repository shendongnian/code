    using System.IO.MemoryMappedFiles;
    using System.IO;
    ...
    string filename = @"filename";
    
    long length = new FileInfo(filename).Length;
    
    using (var file = MemoryMappedFile.CreateFromFile(filename, FileMode.Open))
    using (var accessor = file.CreateViewAccessor()) {
        // Reverse
        long i = 0;
        long j = length - 1;
        byte tmp;
        while (j > i)
        {
            tmp = accessor.ReadByte(j);
            accessor.Write(j, accessor.ReadByte(i));
            accessor.Write(i, tmp);
            j--;
            i++;
        }
    }
