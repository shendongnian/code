    static string FormatAsBytes(IList<byte> bytes)
    {
        var blocks = 
            bytes.ToObservable().Buffer(8).ToEnumerable()
                 .Select(bs => String.Join(" ", 
                    bs.Select(b => String.Format("{0:X2}", (int)b)))
                 );
                 
        return String.Join("  ", blocks).PadRight(17*3, ' ');
    }
