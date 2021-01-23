    public class CallOverview
    {
        public IEnumerable<DateTimeWrapper> Days { get; set; }
    
        public class DateTimeWrapper
        {
            [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dddd dd MMMM yyyy}")]
            public DateTime Value { get; set; }
        }
    }
