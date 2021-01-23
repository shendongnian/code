    public class Attributes
    {
        public double length { get; set; }
        public double time { get; set; }
        public string text { get; set; }
        public long ETA { get; set; }
        public string maneuverType { get; set; }
    }
    
    public class RootObject
    {
        public Attributes attributes { get; set; }
        public string compressedGeometry { get; set; }
    }
