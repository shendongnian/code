    public static bool? CheckExpired()
        {
            DateTime expiryDate, currentDate = DateTime.Today;
            DateTime.TryParse(date, out expiryDate);
            if (expiryDate == new DateTime())
            {
                return null;
            }
            if (expiryDate > currentDate)
            {
                return true;
            }
            else 
            { return false; }
        }
