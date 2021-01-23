    public class Bike
    {
        public int id { get; set; }
        public string modelName { get; set; }
        public IList<Tires> tires { get; set; }
    }
    
    public class Tires
    {
        public int id { get; set; }
        public string tread { get; set; }
    }
