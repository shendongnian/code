    public DateTime? ParseDate(string dateString)
    {
        DateTime dt;
        if (DateTime.TryParse(dateString, out dt))
        {
            return dt;
        }
        else
        {
            return null;
        }
    }
