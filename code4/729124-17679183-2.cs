    public static string StringWordsRemove(string stringToClean)
    {
        // Define how to tokenize the input string, i.e. space only or punctuations also
        return string.Join(" ", stringToClean
            .Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries)
            .Except(wordsToRemove));
    }
