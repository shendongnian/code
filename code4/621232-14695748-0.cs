    public enum ExipiryStatus
    {
        Expired,
        NotExpired,
        InvalidDate
    }
    public static ExipiryStatus CheckExpired(string date)
    {
        DateTime expiryDate, currentDate = DateTime.Today;
        if (DateTime.TryParse(date, out expiryDate))
        {
            if (expiryDate > currentDate)
            {
                return ExipiryStatus.Expired;
            }
            else
            {
                return ExipiryStatus.NotExpired;
            }
        }
        else
        {
            return ExipiryStatus.InvalidDate;
        }
    }
