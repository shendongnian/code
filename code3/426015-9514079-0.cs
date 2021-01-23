    public DateTime? Test(string nextDate)
    {
        if (nextDate == "TBC")
        {
            return null;
        }
        DateTime parsed;    
        if (!DateTime.TryParse(nextDate, out parsed))
        {
            throw new Exception();
        }
        return parsed;
    }
