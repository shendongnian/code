    public class TimedDataItem   
    {
        public DateTime Timestamp { get; set; }
    }
    class TimedDataItemComparer : IComparer<TimedDataItem>
    {
        public int Compare(TimedDataItem x, TimedDataItem y)
        {
            return x.Timestamp.CompareTo(y.Timestamp);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<TimedDataItem> ss = 
                new SortedSet<TimedDataItem>(new TimedDataItemComparer());
            // example data
            ss.Add(new TimedDataItem() { Timestamp = DateTime.Now.AddDays(-5) });
            TimedDataItem min = new TimedDataItem() { Timestamp = DateTime.Now.AddDays(-3) };
            ss.Add(min);
            ss.Add(new TimedDataItem() { Timestamp = DateTime.Now.AddDays(-1) });
            ss.Add(new TimedDataItem() { Timestamp = DateTime.Now });
            ss.Add(new TimedDataItem() { Timestamp = DateTime.Now.AddDays(1) });
            TimedDataItem max = new TimedDataItem() { Timestamp = DateTime.Now.AddDays(3) };
            ss.Add(max);
            ss.Add(new TimedDataItem() { Timestamp = DateTime.Now.AddDays(5) });
            // get elements in range
            SortedSet<TimedDataItem> view = ss.GetViewBetween(min, max);
            foreach (TimedDataItem item in view)
            {
                Console.WriteLine(item.Timestamp);
            }
        }    
    }
