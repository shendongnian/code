    try {
        Regex regexObj = new Regex(@"(?<=SSID \d+ : *)(?<value>\S+)");
        Match matchResults = regexObj.Match(subjectString);
        while (matchResults.Success) {
            for (int i = 1; i < matchResults.Groups.Count; i++) {
                Group groupObj = matchResults.Groups[i];
                if (groupObj.Success) {
                    // matched text: groupObj.Value
                    // match start: groupObj.Index
                    // match length: groupObj.Length
                } 
            }
            matchResults = matchResults.NextMatch();
        } 
    } catch (ArgumentException ex) {
        // Syntax error in the regular expression
    }
