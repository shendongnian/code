    public bool IsBirthdayImminent
    {
        get 
        { 
            if (DateOfBirth == null) 
                return false;
            else
            {
                DateTime birthdayThisYear;
                if (birthDate.Month == 2 && birthDate.Day == 29 && DateTime.IsLeapYear(DateTime.Now.Year))
                    birthdayThisYear = new DateTime(DateTime.Now.Year, 2, 28);
                else
                    birthdayThisYear = new DateTime(DateTime.Now.Year, birthDate.Month, birthDate.Day);
                return birthdayThisYear > DateTime.Now && (birthdayThisYear - DateTime.Now).TotalDays <= 7;
            }
        }
    }
