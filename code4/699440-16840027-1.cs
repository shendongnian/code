    public bool ContainsUnicodeCharacter(char[] input)
    {
        const int MaxAnsiCode = 255;
        return s.Any(c => c > MaxAnsiCode);
    }
