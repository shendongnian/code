    public static string IncrementAccountNumber(string accountNumber) {
        Regex _AccountNumberParser = new Regex(@"(?<digits>[0-9]+)|(?<nonDigits>[^0-9]+)");
        // Work right to left
        var matches = _AccountNumberParser.Matches(accountNumber);
        var parts = new Stack<string>(matches.Count);
            
        bool hasIncremented = false;
        foreach (var currentMatch in matches.Cast<Match>().Reverse()) {
            var digits = currentMatch.Groups["digits"].Value;
            var nonDigits = currentMatch.Groups["nonDigits"].Value;
            if(nonDigits.Length > 0) {
                // simple case
                parts.Push(nonDigits);
                continue;
            }
            var digitsVal = Int64.Parse(digits);
            
            var newDigitsVal = digitsVal;
            if(!hasIncremented) {
                newDigitsVal++;
                hasIncremented = true;
            }
            var newDigits = newDigitsVal.ToString(CultureInfo.InvariantCulture);
            parts.Push(newDigits);
        }
        return String.Join("", parts);
    }
