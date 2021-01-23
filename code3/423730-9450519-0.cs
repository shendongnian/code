    public bool MonthPeriodicityChecker (DateTime start, DateTime end,
        DateTime dateToCheck, int periodicity)
    {
         var monthDiff = dateToCheck.Month - startDate.Month + 12;
         return (monthDiff % periodicity) == 0;
    }
