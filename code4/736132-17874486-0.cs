    [AttributeUsage(AttributeTargets.All)]
    public class HelpAttribute : System.Attribute
    {
        // Required parameter
        public HelpAttribute(string url) 
        {
            this.Url = url;
        }
        // Optional parameter
        public string Topic { get; set; }
        public readonly string Url;
    }
    public class Whatever
    {
        [Help("http://www.stackoverflow.com")]
        public int ID { get; set; }
        [Help("http://www.stackoverflow.com", Topic="MyTopic")]
        public int Wew { get; set; }
        // [Help] // without parameters does not compile
        public int Wow { get; set; }
    }
