    public class Centroid
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
    
    public class Properties
    {
        public string osm_element { get; set; }
        public string amenity { get; set; }
        public string synthesized_name { get; set; }
        public string osm_id { get; set; }
    }
    
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
    
    public class Location
    {
        public string county { get; set; }
        public string country { get; set; }
        public string road { get; set; }
        public string city { get; set; }
    }
    
    public class Feature
    {
        public int id { get; set; }
        public Centroid centroid { get; set; }
        public List<List<double>> bounds { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
        public Location location { get; set; }
        public string type { get; set; }
    }
    
    public class Properties2
    {
        public int code { get; set; }
        public List<int> coordinate_order { get; set; }
    }
    
    public class Crs
    {
        public string type { get; set; }
        public Properties2 properties { get; set; }
    }
    
    public class RootObject
    {
        public int found { get; set; }
        public List<List<double>> bounds { get; set; }
        public List<Feature> features { get; set; }
        public string type { get; set; }
        public Crs crs { get; set; }
    }
