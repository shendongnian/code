    public static DateTime? WrapperConvertFromUtcToCentral(string UtcTime)
    {
        DateTime value = ConvertFromUtcToCentral(string UtcTime);
        if (value == default(DateTime))
             return (DateTime?)null;
        else
             return (DateTime?)value;
    }
    TerminationDate = WrapperConvertFromUtcToCentral(r.TerminationDate.ToString())        
