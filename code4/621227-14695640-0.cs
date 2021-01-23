    public static bool CheckExpired()
    {
        DateTime expiryDate, currentDate = DateTime.Today;
        
        if (!DateTime.TryParse(date, out expiryDate))
        {
             throw new Exception("Invalid date");
        }
        return (expiryDate > currentDate);
    }
