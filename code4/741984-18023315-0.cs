    public static int GetFirstNonPunctuationCharIndex(string input, int startIndex, char[] punctuation)
    {
        //Move the startIndex forward one because we ignore the index user set
        startIndex = startIndex + 1 < input.Length ? startIndex + 1 : input.Length;                 
   
        for (int i = startIndex  ; i < input.Length; i++)
        {
            if (!punctuation.Contains(input[i]) && !Char.IsWhiteSpace(input[i]))
            {
                 return i;
            }
        }
 
        return -1;
    }
