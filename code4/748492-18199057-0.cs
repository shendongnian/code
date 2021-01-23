    public string AvailableToday
    {
        get
        {
            if (NonAvailibility != null)
            {
                var i = NonAvailibility.FirstOrDefault(t => DateTime.UtcNow.Date <= t.EndDate && DateTime.UtcNow.Date >= t.StartDate);
                if (i != null) return i.NonAvailibilityType ;
                return "";
            }
            return "";
        }
    }
