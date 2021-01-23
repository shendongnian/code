    public static string SplitString(string someText)
    {
        var queryArray = Regex.Split(someText, "\\s+(?=\\w+)");
        foreach (var item in queryArray) {
            // Some code
        }
    }
