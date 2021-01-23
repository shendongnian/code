    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        ...
        // Navigation
        public virtual IEnumerable<Task> Tasks { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }
    }
    
    public class Task
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Name { get; set; }
        ...
        // Navigation
        public virtual IEnumerable<Message> Messages { get; set; }
    }
    
    public class Message
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        ...
        public int? ProjectId {get;set;}
        public int? TaskId {get;set;}
        public virtual Project {get;set;}
        public virtual Task {get;set;}
    }
