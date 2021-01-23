    "([^"]*)"
    StringCollection resultList = new StringCollection();
    Regex regexObj = new Regex("\"([^\"]*)\"", RegexOptions.Singleline);
    Match matchResult = regexObj.Match(subjectString);
    while (matchResult.Success) {
    	resultList.Add(matchResult.Groups[1].Value);
    	matchResult = matchResult.NextMatch();
    } 
