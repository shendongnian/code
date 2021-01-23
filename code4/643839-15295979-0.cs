    private static Regex regexInt = new Regex("^\\d+$");
    static bool CheckReg(string value)
    {
        return regexInt.IsMatch(value);
    }
