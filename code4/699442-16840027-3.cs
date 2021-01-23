    public static bool ContainsUnicodeCharacter(this IEnumerable<char> input)
    {
        const int MaxAnsiCode = 255;
        return input.Any(c => c > MaxAnsiCode);
    }
