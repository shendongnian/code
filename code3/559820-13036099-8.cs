    public class ItemInfo {     
       public string action { get; set; }     
       public string timestamp { get; set; }     
       public string url { get; set; }     
       public string ip { get; set; } 
    }
    public class ContainerType {
        public int total;
        public Dictionary<string, ItemInfo[]> data;
    }
