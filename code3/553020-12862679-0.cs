    public static string SplitString(string someText)
    {
        var queryArray = Regex.Split(someText, "\\s+(?=\\w+)");
        foreach (var i in Enumerable.Range(0, queryArray.Length - 1)) {
            // Some code
        }
    }
