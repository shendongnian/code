    static string[] overrides = { "", "__/__/____" };
    public bool ValidateDate(string date, out string message)
    {
        bool success = true;
        message = string.Empty;
        if(overrides.contains(date)) { return success; }
        DateTime dateTime;
    
        if(DateTime.TryParse(date,out dateTime))
        {
            success = false;
            message = "Date is Invalid";
        }
    
    
        return success;
    }
