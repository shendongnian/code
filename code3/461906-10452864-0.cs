    string input = "GS3R2C1234g";
    string pattern = @"(\d*)";
    var matches = Regex.Matches(input, pattern);
    var lastMatch = matches[matches.Length - 1];
    var value = int.Parse(lastMatch.Value);
    value++;
    var newValue = String.Format("{0}{1}{2}"input.Substring(0,lastMatch.Index), 
        value, input.Substring(lastMatch.Index+lastMatch.Length));
