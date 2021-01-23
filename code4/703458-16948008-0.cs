    public bool IsBirthdayImminent
    {
        get 
        { 
            if (DateOfBirth == null) 
                return false;
            else
                return (new DateTime(DateTime.Now.Year, DateOfBirth.Month, DateOfBirth.Day) - DateTime.Now).TotalDays <= 7;
        }
    }
