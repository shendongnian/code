    public class Processor {
        public Uri WebSite { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    var processorCreds = new Dictionary<string, Processor> {
        { "ProcOne", new Processor { WebSite = new Uri("[url]"), 
                                     UserName = "[username]", 
                                     Password = "[password]" } },
        { "ProcTwo", new Processor { WebSite = new Uri("[url]"), 
                                     UserName = "[username]", 
                                     Password = "[password]" } }
    };
