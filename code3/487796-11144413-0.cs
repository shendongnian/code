    // Nasty, but it does work...
    void SplitInTwo(string input, out string x1, out string x2, 
                    out int actualSplitCount)
    {
        string[] bits = input.Split('/');
        x1 = bits[0];
        x2 = bits[1];
        actualSplitCount = bits.Length;
    }
