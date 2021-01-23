    class Program
    {
        static void Main(string[] args)
        {
            TimeBand.DoSomething();
        }
    }
    public class TimeBand
    {
        public DayOfWeek DayName { get; set; }
        public int customerId { get; set; }
        public static void DoSomething()
        {
            var TimeBandList = new List<TimeBand>
                {
                    new TimeBand()
                        {
                            DayName = DayOfWeek.Monday,
                            customerId = 10
                        },
                    new TimeBand()
                        {
                            DayName = DayOfWeek.Tuesday,
                            customerId = 11
                        }
                };
                DateTime date = DateTime.Now;
                var timeBandRange = new List<TimeBand>();
                timeBandRange = TimeBandList.Where
                              (p => p.customerId == 1  
                                 && p.DayName == date.DayOfWeek).ToList();
                    }
                }
