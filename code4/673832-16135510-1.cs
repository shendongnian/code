    class Program
        {
            static void Main(string[] args)
            {
                List<DateInterval> intervals = new List<DateInterval>();
                intervals.Add(new DateInterval(Convert.ToDateTime("26 April 2013"), Convert.ToDateTime("27 April 2013")));
                intervals.Add(new DateInterval(Convert.ToDateTime("16 April 2013"), Convert.ToDateTime("24 April 2013")));
                intervals.Add(new DateInterval(Convert.ToDateTime("20 April 2013"), Convert.ToDateTime("28 April 2013")));
                intervals.Add(new DateInterval(Convert.ToDateTime("16 April 2013"), Convert.ToDateTime("28 April 2013")));
    
                DateInterval toCheck = new DateInterval(Convert.ToDateTime("16 April 2013"),
                                                        Convert.ToDateTime("25 April 2013"));
    
                var overlappingIntervals = intervals
                    .Where(r => 
                        (r.Start <= toCheck.Start && r.End >= toCheck.End) //inside a timeframe
                    || (r.Start >= toCheck.Start && r.End <= toCheck.End) //other is inside our timeframe
                    || (r.Start >= toCheck.Start && r.End >= toCheck.End && r.Start <=toCheck.End) //end overlap
                    || (r.Start <= toCheck.Start && r.End <= toCheck.End && r.End >= toCheck.Start)// start overlap
                        
                    ).ToList();
                Console.Write(overlappingIntervals.Count);
    
            }
        }
    
    
        public class DateInterval
        {
    
            public DateInterval(DateTime Start, DateTime End)
            {
                this.Start = Start;
                this.End = End;
            }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
