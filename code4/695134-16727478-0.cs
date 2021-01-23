    public static string SpliceText(string text, int lineLength)
    {
        var lines = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .GroupBy(w => (charCount += w.Length + 1) / lineLength)
                        .Select(g => string.Join(" ", g));
        return String.Join(string.Empty, los.ToArray());
    }
