    public class Route
    {
        public Address from { get; set; }
        public Address to { get; set; }
        public Route()
        {
            from = new Address();
            to = new Address();
        }
    }
