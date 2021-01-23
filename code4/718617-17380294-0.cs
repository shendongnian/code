    public bool isDate(string date)
    {
        var result = new DateTime();
        return DateTime.TryParse(date, out result);
    }
