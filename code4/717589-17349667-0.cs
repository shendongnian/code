    public string GetDtString(DateTime dt)
    {
        RegEx rgx = new RegEx("[1-9]0+Z\b");
        return rgx.Replace(dt.ToString("o"), System.String.Empty);
    }
