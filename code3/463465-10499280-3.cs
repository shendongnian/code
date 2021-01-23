    class Data
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Value { get; set; }
    }
    // Just setup some test data simulary to your example
    IList<Data> testList = new List<Data>();
    DateTime date = DateTime.Parse("6:00"); 
    
    // This loop fills just some data over several years, months and days
    for (int year = date.Year; year > 2010; year--)
    {
        for(int month = date.Month; month > 0; month--)
        {
            for (int day = date.Day; day > 0; day--)
            {
                for(int hour = date.Hour; hour > 0; hour--)
                {
                    DateTime testDate = date.AddHours(-hour).AddDays(-day).AddMonths(-month).AddYears(-(date.Year - year));
                    testList.Add(new Data() { Start = testDate, End = testDate.AddMinutes(30), Value = 1 });
                    testList.Add(new Data() { Start = testDate.AddMinutes(30), End = testDate.AddHours(1), Value = 1 });
                }
            }
        }
    }
