    public class Sort : IComparable<Sort>
    {
        public string Count { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public virtual int CompareTo(Sort obj)
        {
            return (Count.CompareTo(obj.Count));
        }
    }
