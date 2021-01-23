    public string getYear(string str)
    {
        return (string)Regex.Match(str, @"\d{4}").Value;
    }
    var result = getYear("05/11/2010");
    2010
