    public class DateInfo
    {		
        public int Year { get; set; }
        public string Month { get; set; }
        public IEnumerable<int> Days { get; set; }
        public string DisplayDayList
        {
            get
            {
                return string.Join(" ", Days.Select(x=>x.ToString()).ToArray()); //sorry, i'm doing .net 3.5
            }
        }
    }
