    [XmlRoot("users")]
    public class UserResult
    {
        [XmlElement("user")]
        public List<User> Users { get; set; }
    }
    public class User
    {
        [XmlElement("username")]
        public string UserName { get; set; }
        
        [XmlElement("password")]
        public string Password { get; set; }
    }
