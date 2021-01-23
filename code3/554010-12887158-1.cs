    public static String duplicateChars(IEnumerable<Char> input, int factor)
    {
        var chars = from c in input
                    from cc in Enumerable.Repeat(c, factor)
                    select cc;
        return new String(chars.ToArray());
    }
      
