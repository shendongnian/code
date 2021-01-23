    public class Task
    {
        public object id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int level { get; set; }
        public string status { get; set; }
        public object start { get; set; }
        public int duration { get; set; }
        public object end { get; set; }
        public bool startIsMilestone { get; set; }
        public bool endIsMilestone { get; set; }
        public bool collapsed { get; set; }
        public List<object> assigs { get; set; }
    }
    
    public class Resource
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class RootObject
    {
        public List<Task> tasks { get; set; }
        public int selectedRow { get; set; }
        public List<object> deletedTaskIds { get; set; }
        public List<Resource> resources { get; set; }
        public List<Role> roles { get; set; }
        public bool canWrite { get; set; }
        public bool canWriteOnParent { get; set; }
    }
