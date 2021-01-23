    static string FormatAsBytes(IList<byte> bytes)
    {
        var blocks = 
            bytes.Buffer(8)
                 .Select(bs => String.Join(" ", 
                    bs.Select(b => String.Format("{0:X2}", (int)b)))
                 );
                 
        return String.Join("  ", blocks);
    }
