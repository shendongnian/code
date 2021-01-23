    public static string IncrementAccountNumberWithCarry(string accountNumber) {
        bool hasIncremented = false;
        bool needToCarry = false;
        var result = String.Join("",
                        _ReverseAccountNumberParser
                            .Matches(accountNumber)
                            .Cast<Match>()
                            .Select(m => {
                                var nonDigits = m.Groups["nonDigits"].Value;
                                if (nonDigits.Length > 0) {
                                    return nonDigits;
                                }
                                var oldDigitVal = m.Groups["digits"].Value;
                                var digitVal = Int64.Parse(oldDigitVal);
                                if(needToCarry) {
                                    digitVal++;
                                }
                                if (!hasIncremented) {
                                    digitVal++;
                                    hasIncremented = true;
                                }
                                var newDigitVal = digitVal.ToString();
                                needToCarry = newDigitVal.Length > oldDigitVal.Length;
                                if(needToCarry) {
                                    newDigitVal = newDigitVal.Substring(1);
                                }
                                    
                                return newDigitVal;
                            })
                            .Reverse());
        if(needToCarry) {
            result = "1" + result;
        }
        return result;
    }
