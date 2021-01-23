    public class CrateOfBags<T>
    {
        public string crateId { get; set; }
        public string originCountry { get; set; }
        public List<Bag<T> bagList { get; set; }
    }
    
    public class Bag<T>
    {
        public double weight { get; set; }
        public string bagId { get; set; }
        public List<T> ItemList { get; set; }
    }
    
    public class apple
    {
        public string appleId { get; set; }
        public string color { get; set; }
        public Boolean rotten { get; set; }
    }
