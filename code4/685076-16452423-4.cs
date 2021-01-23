    public class Instance2
    {
        public string Stop {get;set;}
        public string Restart {get;set;}
        public string Backup {get;set;}
    } 
    Dictionary<String, Instance2> items = new Dictionary<String, Instance2>();
    // ...
    items[name] = new Instance2(){Stop = stop,
        Restart = restart,
        Backup = backup};
