    public struct DatePart
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime Date { get { return new DateTime(Year, Month, Day); } }
    }
