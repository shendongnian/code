    public IEnumerable<DateTime> GetAlternatingFridaysStartingFrom(DateTime startDate)
    {
        DateTime tempDate = new DateTime(startDate.year, startDate.Month, startDate.Day);
        if(tempDate.DayOfWeek != DayOfWeek.Friday)
        {
            // Math may be off, do some testing
            tempDate = tempDate.AddDays((7 - ((int)DayOfWeek.Friday - (int)tempDate.DayOfWeek) % 7);
        }
        while(true)
        {                
            yield return tempDate;
            tempDate = tempDate.AddDays(14);
        }
    }
