        public class MegaWidget
        {
            public Dictionary<string, Location> Locations { get; set; }
        }
    
        public class Location
        {
            public List<Part> Contents { get; set; }
        }
    
        public class Part
        {
            public int Id { get; set; }
            public string PartName { get; set; }
        }
