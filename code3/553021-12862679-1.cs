    public static string SplitString(string someText)
    {
        var queryArray = Regex.Split(someText, "\\s+(?=\\w+)");
        for (var i = 0; i < queryArray.Length; i++) {
            // Some code
        }
    }
