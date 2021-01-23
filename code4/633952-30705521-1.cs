    public static IEnumerable<string> SplitIntoWords(this string text)
    {
        string pattern = @"\b[\p{L}]+\b";
        return
            Regex.Matches(text, pattern)
                .Cast<Match>()                          // Extract matches
                .Select(match => match.Value.ToLower()) // Change to same case
                .Distinct();                            // Remove duplicates
    }
