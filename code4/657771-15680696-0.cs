    public class NodeDataArray
    {
        public string key { get; set; }
        public string type { get; set; }
        public string devicename { get; set; }
        public string imageUrl { get; set; }
        public string loc { get; set; }
    }
    
    public class RootObject
    {
        public string @class { get; set; }
        public List<NodeDataArray> nodeDataArray { get; set; }
        public List<object> linkDataArray { get; set; }
    }
