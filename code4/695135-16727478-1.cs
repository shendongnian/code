    public static string SpliceText(string text, int lineLength)
    {
        var charCount = 0;
        var lines = text.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .GroupBy(w => (charCount += w.Length + 1) / lineLength)
                        .Select(g => string.Join(" ", g));
        return String.Join("\n", lines.ToArray());
    }
