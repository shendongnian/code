    // make a pattern to match all words 
    var pattern = string.Format(
        @"\b({0})\b",
        string.Join("|", wordsToremove.Split(new[] { ' ' })));
    // pattern will be of the form "\b(badword1|badword2|...)\b"
    // remove all the bad words from the string in one go.    
    var cleanString = Regex.Replace(stringToClean, pattern, string.Empty);
    // normalise the white space in the string (one space at a time)
    var normalisedString = Regex.Replace(cleanString, @"\s+", " ");
