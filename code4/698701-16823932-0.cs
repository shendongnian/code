    public override bool IsValid(DateTime value)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - value.Year;
        if (value > today.AddYears(-age)) age--;
        if (age < 18)
        {
            return false;
        }
        return true;
    }
    public override bool IsValid(string value)
    {
        string format = "dd/MM/yyyy HH:mm:ss";
        DateTime dt;
        if (DateTime.TryParseExact((String)value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
        {
            return IsValid(dt);
        }
        else
        {
            return false;
        }
   
    }
    public override bool IsValid(object value)
    {
        return IsValid(value.ToString());   
    }
