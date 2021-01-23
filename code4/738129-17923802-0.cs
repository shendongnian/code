    public class Root
    {
        public string Status { get; set; }
        public Result Result { get; set; }
    }
    
    public class Result
    {
        public bool? Value { get; set; }
        public Item[] Items { get; set; }
    }
    
    public class Item
    {
        public string Name { get; set; }
        public string UserIdentifier { get; set; }
        public string MaxAccounts { get; set; }
    }
