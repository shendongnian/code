    public class Config
    {
        [XmlElement("email-settings")]
        public Email Email { get; set; }
        public Program Program { get; set; }
        [XmlElement("database-settings")]
        public Database Database { get; set; }
    }
    public class Email
    {
        public string Recipient { get; set; }
        [XmlElement("Server-port")]
        public int ServerPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Program
    {
        public string Filename { get; set; }
        
        public string Filepath { get; set; }
    }
    public class Database
    {
        public string serialId { get; set; }
    }
