    private static readonly Regex _AccountNumberParser = new Regex("(?<digits>[0-9]+)|(?<nonDigits>[^0-9]+)");
    public static string IncrementAccountNumber(string accountNumber) {
        bool hasIncremented = false;
        return String.Join("", 
                        _AccountNumberParser
                            .Matches(accountNumber)
                            .Cast<Match>()
                            .Reverse()
                            .Select(m => {
                                var nonDigits = m.Groups["nonDigits"].Value;
                                if(nonDigits.Length > 0) {
                                    return nonDigits;
                                }
                                var digitVal = Int64.Parse(m.Groups["digits"].Value);
                                if(!hasIncremented) {
                                    digitVal++;
                                    hasIncremented = true;
                                }
                                return digitVal.ToString();
                            })
                            .Reverse());
    }
