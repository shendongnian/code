    public class Registration
    {
        public string created { get; set; }
        public string expires { get; set; }
        public string updated { get; set; }
        public string registrar { get; set; }
        public List<string> statuses { get; set; }
    }
    
    public class Whois
    {
        public string date { get; set; }
        public string record { get; set; }
    }
    
    public class Response
    {
        public string registrant { get; set; }
        public Registration registration { get; set; }
        public List<string> name_servers { get; set; }
        public Whois whois { get; set; }
    }
    
    public class RootObject
    {
        public Response response { get; set; }
    }
