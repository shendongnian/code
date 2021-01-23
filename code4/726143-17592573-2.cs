    public string TrimLongWords(string input, int maxWordLength)
    {
        StringBuilder sb = new StringBuilder(input.Length);
        int currentWordLength = 0;
        bool wasLetter = false;
        foreach (char c in input)
        {
            bool isLetter = char.IsLetter(c);
            if (currentWordLength < maxWordLength || !isLetter)
            {
                sb.Append(c);
                if (isLetter)
                    currentWordLength++;
                else
                    currentWordLength = 0;
            }
            else if (!wasLetter)
                sb.Append("...");
            wasLetter = isLetter;
        }
        return sb.ToString();
    }
