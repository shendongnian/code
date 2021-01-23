    public class Sender
    {
    public string id {get;set;}
    public string name {get;set;}
    }
    
    public class FacebookPost 
    {
    public string id        { get; set; }
    public Sender from      { get; set; }
    public string message   { get; set; }
    }
