    public class Key2
    {
    }
    
    public class Key3
    {
        public List<string> key4 { get; set; }
        public string key5 { get; set; }
    }
    
    public class Key9
    {
    }
    
    public class Key10
    {
        public List<string> key4 { get; set; }
        public string key9 { get; set; }
    }
    
    public class Datum
    {
        public int key1 { get; set; }
        public Key2 key2 { get; set; }
        public Key3 key3 { get; set; }
        public int key7 { get; set; }
        public int? key8 { get; set; }
        public Key9 key9 { get; set; }
        public Key10 key10 { get; set; }
        public int? key11 { get; set; }
    }
    
    public class RootObject
    {
        public string serverTime { get; set; }
        public List<Datum> data { get; set; }
    }
