    public string TrimLongWords(string input, int maxWordLength)
    {
        StringBuilder sb = new StringBuilder(input.Length);
        int currentWordLength = 0;
        foreach (char c in input)
        {
            bool isLetter = char.IsLetter(c);
            if (currentWordLength < maxWordLength || !isLetter)
            {
                sb.Append(c);
                currentWordLength++;
            }
            else
                sb.Append("...");
        }
        return sb.ToString();
    }
