    public static Regex _regex = new Regex(
        @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        RegexOptions.CultureInvariant | RegexOptions.Singleline);
    public static bool IsValidEmailFormat(string emailInput)
    {
        return _regex.IsMatch(emailInput);
    }
