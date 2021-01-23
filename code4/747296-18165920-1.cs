    var now = DateTime.Now;
    var totalYears = now.Year - secondDate.Year;
    
    if (secondDate.Month > now.Month || (secondDate.Month == now.Month && secondDate.Day > now.Day))
    {
        totalYears--;
    }
    
    var months = now.Month - secondDate.Mont;
    
    if (secondDate.Day > now.Day)
    {
        months--;
    }
    if (months < 0)
    {
        months = 12 + months;
    }
