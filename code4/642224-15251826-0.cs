    public static string FormatLicenseNumber(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        else
        {
            str = str.Replace("-", string.Empty);
            if (str.Length > 20)
                str = str.Insert(20, "-");
            if (str.Length > 15)
                str = str.Insert(15, "-");
            if (str.Length > 10)
                str = str.Insert(10, "-");
            if (str.Length > 5)
                str = str.Insert(5, "-");
            return str;
        }
    }
