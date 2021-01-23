    public static string ExtractVowels(string text)
    {
        // Note that this won't find upper-case vowels...
        var vowelArray = text.Where(c => "aeiou".Contains(c))
                             .ToArray();
        // Upper-case it if you want, of course.
        return new string(vowelArray);
    }
