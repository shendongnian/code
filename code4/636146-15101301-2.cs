    public class DateRange
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public static DateRange OfYear(int year)
        {
            return new DateRange
            {
                BeginDate = new DateTime(year, 1, 1),
                EndDate = new DateTime(year, 12, 31)
            };
        }
        public static DateRange OfMonth(int month)
        {
            var year = DateTime.Today.Year;
            return new DateRange
            {
                BeginDate = new DateTime(year, month, 1),
                EndDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1)
            };
        }
    }
