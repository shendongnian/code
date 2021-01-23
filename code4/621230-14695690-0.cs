    public static bool? CheckExpired(string date)
    {
        DateTime expiryDate;
        DateTime currentDate = DateTime.Today;
        
        if (!DateTime.TryParse(date, out expiryDate))
        {
            return null;
        }
        return (expiryDate > currentDate);
    }
