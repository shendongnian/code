    public string ShowEmailAsGmail(DateTime dt)
    {
        DateTime now = DateTime.UtcNow;
        if (dt.Date == now.Date)
            return dt.ToString("hh:mm tt");
        
        return dt.ToString("MMM dd");
    }
