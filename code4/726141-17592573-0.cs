    public string TrimLongWords(string input, int maxWordLength)
    {
        StringBuilder sb = new StringBuilder(input.Length);
        int currentWordLength = 0;
        foreach (char c in input)
        {
            bool isLetter = char.IsLetter(c);
            if (isLetter && currentWordLength < maxWordLength)
            {
                sb.Append(c);
                currentWordLength++;
            }
            else if (!isLetter)
            {
                sb.Append(c);
                currentWordLength = 0;
            }
        }
        return sb.ToString();
    }
