    public class WorkItem
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public WorkItem()
        {
        }
        public override string ToString()
        {
            return Value;
        }
    }
