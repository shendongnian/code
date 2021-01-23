    public class DateInfo
    {		
        public int Year { get; private set; }
        public string Month { get; private set; }
        public IEnumerable<int> Days { get; private set; }
        public string DisplayDayList
        {
            get
            {
                return string.Join(" ", Days.Select(x=>x.ToString()).ToArray()); //sorry, i'm doing .net 3.5
            }
        }
    }
