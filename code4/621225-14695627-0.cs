        public static bool? CheckExpired(string date)
        {
            DateTime expiryDate, currentDate = DateTime.Today;
            if (DateTime.TryParse(date, out expiryDate))
            {
                return expiryDate > currentDate;
            }
            return null;
        }
