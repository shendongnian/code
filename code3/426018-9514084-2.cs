    public DateTime? Test(string nextDate)
    {
        DateTime parsed;
    
        if (nextDate == "TBC" )
           return null;
    
        if(!DateTime.TryParse(nextDate, out parsed))
          throw new Exception();
    
        return parsed;  
    }
