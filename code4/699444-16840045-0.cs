    public bool ContainsUnicodeCharacter(char[] input)
    {
        const int MaxAnsiCode = 255;
        return input.Any(c => c > MaxAnsiCode);
    }
