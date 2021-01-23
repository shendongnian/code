    class MonthDayYearDateConverter : IsoDateTimeConverter
    {
        public MonthDayYearDateConverter()
        {
            DateTimeFormat = "MM.dd.yyyy";
        }
    }
    class LongDateConverter : IsoDateTimeConverter
    {
        public LongDateConverter()
        {
            DateTimeFormat = "MMMM dd, yyyy";
        }
    }
