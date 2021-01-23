    public class RouteInfo
    {
        public List<string> Directions { get; set; }
        public string RouteID { get; set; }
    }
    public class RouteData
    {
        public int Status { get; set; }
        public string Timestamp { get; set; }
        public List<RouteInfo> Routes { get; set; }
    }
