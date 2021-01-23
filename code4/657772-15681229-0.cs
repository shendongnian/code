    public class FloorplanItem
    {
        public string Class { get; set; }
        public NodeDataArray[] NodeDataArray { get; set; }
        public object[] LinkDataArray { get; set; }
    }
    public class NodeDataArray
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string DeviceName { get; set; }
        public string ImageUrl { get; set; }
        public string Loc { get; set; }
    }
