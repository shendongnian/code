    private static bool IsDate(string inputText)
    {
        DateTime d;
        return DateTime.TryParse(inputText, out d);
    }
