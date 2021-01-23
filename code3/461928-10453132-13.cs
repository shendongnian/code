    private static readonly Regex _ReverseAccountNumberParser = new Regex("(?<digits>[0-9]+)|(?<nonDigits>[^0-9]+)", RegexOptions.RightToLeft);
    public static string IncrementAccountNumber(string accountNumber) {
        bool hasIncremented = false;
        return String.Join("", 
                        _ReverseAccountNumberParser
                            .Matches(accountNumber)
                            .Cast<Match>()
                            .Select(m => {
                                var nonDigits = m.Groups["nonDigits"].Value;
                                if(nonDigits.Length > 0) {
                                    return nonDigits;
                                }
                                var digitVal = Int64.Parse(m.Groups["digits"].Value);
                                if(!hasIncremented) {
                                    digitVal++;
                                }
                                hasIncremented = true;
                                return digitVal.ToString();
                            })
                            .Reverse());
    }
