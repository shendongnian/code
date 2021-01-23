    public class userdetails
    { 
        public Guid userid { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
    public class bids
    {
        public int id { get; set; }
        public int carid { get; set; }
        public int bidamount { get; set; }
        public DateTime dateplaced { get; set; }
        public Guid userid { get; set; }
    }
    public class  cars
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descr { get; set; }
        public int listingOption { get; set; }
        public int priceStarting { get; set; }
        public int priceReserve { get; set; }
        public bool enabled { get; set; }
    }
    public class action_images
    {
        public int id { get; set; }
        public string image { get; set; }
        public int belongs_to { get; set; }
    }
