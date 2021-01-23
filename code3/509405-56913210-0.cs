    string str = "Hel lo world!";
    string rts = "Hello\n   world!";
    char[] skips = { ' ', '\n' };
    if (CompareExcept(str, rts, skips))
        Console.WriteLine("The strings are equal.");
    else
        Console.WriteLine("The strings are not equal.");
    
    static bool CompareExcept(string str, string rts, char[] skips)
    {
        if (str == null && rts == null) return true;
        if (str == null || rts == null) return false;
        var strReader = new StringReader(str);
        var rtsReader = new StringReader(rts);
        char nonchar = char.MaxValue;
        Predicate<char> skiper = delegate (char chr)
        {
            foreach (var skp in skips)
            {
                if (skp == chr) return true;
            }
            return false;
        };
        while (true)
        {
            char a = strReader.GetCharExcept(skiper);
            char b = rtsReader.GetCharExcept(skiper);
            if (a == b)
            {
                if (a == nonchar) return true;
                else continue;
            }
            else return false;
        }
    }
    class StringReader : System.IO.StringReader
    {
        public StringReader(string str) : base(str) { }
        public char GetCharExcept(Predicate<char> compare)
        {
            char ch;
            while (compare(ch = (char)Read())) { }
            return ch;
        }
    }
