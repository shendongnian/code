    public string TrimLongWords(string input, int maxWordLength)
    {
        StringBuilder sb = new StringBuilder(input.Length);
        int currentWordLength = 0;
        bool stopTripleDot = false;
        foreach (char c in input)
        {
            bool isLetter = char.IsLetter(c);
            if (currentWordLength < maxWordLength || !isLetter)
            {
                sb.Append(c);
                stopTripleDot = false;
                if (isLetter)
                    currentWordLength++;
                else
                    currentWordLength = 0;
            }
            else if (!stopTripleDot)
            {
                sb.Append("...");
                stopTripleDot = true;
            }
        }
        return sb.ToString();
    }
