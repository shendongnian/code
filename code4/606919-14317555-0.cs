    public class RootObject
    {
       public RootObject()
       {
          address = new Address();
          technologies = new List<string>();
       }
    
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
        public Address address { get; set; }
        public List<string> technologies { get; set; }
    }
