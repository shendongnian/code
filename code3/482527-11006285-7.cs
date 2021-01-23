    string text = ...; // Load text from DB
    MatchCollection matches = Regex.Matches(text, "[a-z]([:']?[a-z])*",
                                            RegexOptions.IgnoreCase);
    foreach (Match match in matches) {
        if (!stopWords.Contains(match.Value)) {
            ProcessKeyword(match.Value); // Do whatever you need to do here
        }
    }
