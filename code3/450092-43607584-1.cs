      public List<DateObjectClass> SplitDateRangeByDates(DateTime start,DateTime end)
        {
            List<DateObjectClass> datesCollection = new List<DateObjectClass>();
            DateTime startOfThisPeriod = start;
            while (startOfThisPeriod < end)
            {
                DateTime endOfThisPeriod =new DateTime(startOfThisPeriod.Year,startOfThisPeriod.Month,startOfThisPeriod.Day,23,59,59);
                endOfThisPeriod = endOfThisPeriod < end ? endOfThisPeriod : end;
                datesCollection.Add(new DateObjectClass() { startDate= startOfThisPeriod ,endDate  =endOfThisPeriod});
                startOfThisPeriod = endOfThisPeriod;
                startOfThisPeriod = startOfThisPeriod.AddSeconds(1);
            }
            return datesCollection;
        }
