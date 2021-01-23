    class Foo
    {
        [JsonConverter(typeof(MonthDayYearDateConverter))]
        public DateTime Date1 { get; set; }
        [JsonConverter(typeof(LongDateConverter))]
        public DateTime Date2 { get; set; }
        // Use default formatting
        public DateTime Date3 { get; set; }
    }
