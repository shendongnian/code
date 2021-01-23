    public class MyModel
    {
        public string Id {get; set;}
        public string Version { get; set;}
        public string Name { get; set;}
    	
        public string FullId { get {return String.Format("{0}{1}", Id, Version)}}
    }
