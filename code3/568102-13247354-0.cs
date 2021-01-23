    public static DateTime? TryParse(string stringDate)
    {
        DateTime date;
        return DateTime.TryParse(stringDate, out date) ? date : (DateTime?)null;
    }
    
