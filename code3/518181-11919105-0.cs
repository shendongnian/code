    public string ParseMoney(string Sauce)
    {
        string Money = Regex.Match(Sauce, @"\$\d+\sMillion", RegexOptions.IgnoreCase | RegexOptions.Singleline).Value;
        return string.IsNullOrEmpty(Money) ? "Unable to find money." : Money;
    }
