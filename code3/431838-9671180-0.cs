    class Program
    {   
        static void Main(string[] args)
        {
            int interval = 10;
            DateTime isInRangeDate = DateTime.UtcNow;
            for (int i = 1930; i < 2020; )
            {
                DateRange range = new DateRange(1, 1, i, interval);
                Console.WriteLine(string.Format("{0}: Is in range - {1}", range.ToString(), range.IsInsidePeriod(isInRangeDate)));
                i = range.EndDate.Year;
            }               
            Console.ReadLine();
        }  
    }
    public class DateRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public override string ToString()
        {
            return string.Format("{0}-{1}", this.StartDate.Year, this.EndDate.Year);
        }
        public DateRange(int day, int month, int year, int addYears)
        {
            StartDate = new DateTime(year, month, day, 0, 0, 0);
            EndDate = StartDate.AddYears(addYears);
        }
        public bool IsInsidePeriod(DateTime dt)
        {
            return ((dt.Date >= StartDate) && (dt.Date < EndDate));
        }
    }
