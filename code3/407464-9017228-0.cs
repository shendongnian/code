    private static DateTime DoCalculation(DateTime startDate, int minutes)
    {
        if (startDate.DayOfWeek == DayOfWeek.Sunday)
        {
            // if the input date is a sunday, set the actual SLA start date to the following monday morning 7:00AM
            startDate = startDate.AddHours(24);
            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 7, 0, 0);
        }
        else if (startDate.DayOfWeek == DayOfWeek.Saturday)
        {
            // if the input date is a saturday, set the actual SLA start date to the following monday morning 7:00AM
            startDate = startDate.AddHours(48);
            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 7, 0, 0);
        }
        DateTime resultDate = startDate;
        for (int i = 0; i < minutes; i++)
        {
            resultDate = resultDate.AddMinutes(1);
            // it is 5PM and time to go home
            if (resultDate.Hour >= 17)
            {
                // if tomorrow is saturday
                if (resultDate.AddDays(1).DayOfWeek == DayOfWeek.Saturday)
                {
                    //add 48 hours to get us through the whole weekend
                    resultDate = resultDate.AddHours(48);
                }
                // add 14 hours to get us to next morning
                resultDate = resultDate.AddHours(14);
            }
        }
        return resultDate;
    }
