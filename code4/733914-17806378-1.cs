    using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.ReadWrite))
    {
        fs.Seek(-4, SeekOrigin.End);
        fs.Write(userBytes);
        fs.Write(fourBytesAtEnd);      
    }
