    [Serializable]
    public class grandparentnode
    {
        public parentnode parentnode { get; set; }
    }
    
    [Serializable]
    public class parentnode
    {
        [XmlElement]
        public childnode[] childnode { get; set; }
    }
    
    [Serializable]
    public class childnode
    {
        public string foo { get; set; }
        public string bar { get; set; }
        public string baz { get; set; }
    }
