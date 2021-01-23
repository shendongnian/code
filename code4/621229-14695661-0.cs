    public static DateValidationResult CheckExpired(string date)
    {
        DateTime expiryDate, currentDate = DateTime.Today;
        if (!DateTime.TryParse(date, out expiryDate))
            return DateValidationResult.InvalidDate;
    
        return expiryDate > currentDate ? DateValidationResult.Ok : DateValidationResult.Fail;
    }
    
    public enum DateValidationResult
    {
        InvalidDate,
        Ok,
        Fail
    }
