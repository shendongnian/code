    public static bool IsUnicode(string input)    
    {    
        var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
        var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
        return asciiBytesCount != unicodBytesCount;
    }
