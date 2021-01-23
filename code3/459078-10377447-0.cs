    static void Main(string[] args)
    {
        // A perfectly valid surrogate pair with 1st character in the D800-DBFF range,
        // and 2nd character in the DC00-DFFF range.
        string validSurrogate = "\uD801\uDC01";
        // Creating an invalid surrogate pair just by swapping the two bytes in the first string.
        string invalidSurrogate = validSurrogate.Substring(1, 1) + validSurrogate[0];
        // This will work fine.
        File.WriteAllText("valid.txt", validSurrogate);
        // --! But this will crash !--
        File.WriteAllText("invalid.txt", invalidSurrogate);
    }
