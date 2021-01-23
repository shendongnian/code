    private void ParseString(string sInput, ref List<string> sWords, int lCount, string sDel)
    {
        int lWordStart;
        int lWordEnd;
        string sTemp;
        int lParsedArraySize;
        int lDelLen;
        int lLength;
    
        lDelLen = sDel.Length;
    
        lLength = sInput.Length;
    
        if (String.IsNullOrEmpty(sInput)) {
            sWords = new List<string>();
            sWords.Add(""); // Now, sWords[0] will equal "" - this may not be exactly what
            // your VB code expects, but since all C# arrays begin with zero it's the
            // closest approximation.  Alternatively, you could add two items so that
            // sWords[1] would still return the correct value.
        }
        lParsedArraySize = 50;
    }
