    public class Processor {
        public Uri Website { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Processor(Uri website, string username, string password) {
            Website = website;
            Username = username;
            Password = password;
        }
    }
    
    var processorCreds = new Dictionary<string, Processor> {
        { "ProcOne", new Processor(new Uri("[url]"), "[username]", "[password]") },
        { "ProcTwo", new Processor {new Uri("[url]"), "[username]", "[password]") }
    };
