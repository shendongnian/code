    public void CreateNew(WeekDays days)
    {  
        if (!Enum.IsDefined(typeof(WeekDays), days))
            throw new ArgumentException();
    
        // SomeLogic
    }
