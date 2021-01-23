    bool ValidateDate(string date, out string message)
    {
        message = string.Empty;
        if (date == null)
            return true;
        const string mask = "_";
        var separator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
        var test = date.Replace(mask, string.Empty).Replace(separator, string.Empty);
        if (string.IsNullOrWhiteSpace(test))
            return true;
        
        DateTime dateTime;
        if (!DateTime.TryParse(date, out dateTime))
        {
            message = "Date is Invalid";
            return false;
        }
        return true;
    }
