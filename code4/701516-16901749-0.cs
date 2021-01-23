    private static string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <Post>
        <Title>this is a title</Title>
        <ProxyDateTime>2013/06/03</ProxyDateTime>
        <Message>this is a message here</Message>
    </Post>";
    
    public class Post
    {
        public string Title { get; set; }
        public string Message { get; set; }
        [XmlIgnore]
        public DateTime Date { get; set; }
    
        public string ProxyDateTime
        {
            get { return Date.Date.ToString(); }
            set { Date = DateTime.Parse(value); }
        }
    
        public override string ToString()
        {
            return String.Join(Environment.NewLine, 
                new [] {"Title: " + Title, "Date: " + Date, "Message: " + Message});
        }
    }
