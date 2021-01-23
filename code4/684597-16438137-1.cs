    static ulong SliceValue(byte[] bytes, int start, int length)
    {
        var bytes = bytes.Skip(start).Take(length);
    
        ulong acc = 0;
        foreach (var b in bytes) acc = (acc * 0x100) + b;
    
        return acc;
    }
