    public bool IsValid(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;
        string[] array = str.Split('-');
        if (array.Length != 2)
            return false;
        DateTime temp;
        if (!DateTime.TryParseExact(array[0].Trim(), "MMM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
            return false;
        if (!DateTime.TryParseExact(array[1].Trim(), "MMM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
            return false;
        return true;
    }
