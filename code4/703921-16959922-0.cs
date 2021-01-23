    private int CalculateAge(DateTime birthDate, DateTime now)
    {
       TimeSpan span = now.Subtract(birthDate);     
       return (int)span.TotalDays / 365;  
    }
       
