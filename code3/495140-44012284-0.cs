    public class CallOverview
    {
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dddd dd MMMM yyyy}")]
        public PersistableDateTimeCollection<DateTime> Days { get; set; }
    }
