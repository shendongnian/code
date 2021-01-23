    public interface Ibase
    
        string RowKey { get; set; }
        string PartitionKey { get; set; }
    }
    public interface Imust : Ibase
    {
        string Name { get; set; }
        string File { get; set; }
        string Time { get; set; }
    }
    
    public class TA : TableServiceEntity, Imust
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
    }
    
    public class TB : TableServiceEntity, Imust
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
    }
    
    public class TC : TableServiceEntity, Imust
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
    }    
    
    
    public class _BaseTable <T> : _Account where T : Ibase 
    {
    }
    public class _Table <T> : _BaseTable<T> where T : Imust 
    {
    }
