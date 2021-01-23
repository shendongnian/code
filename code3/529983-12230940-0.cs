    // only one xml root element is allowed!
    [Serializable]
    public class User
    {
        public User()
        {       }
        [XmlAttribute("userID")]
        public string UserId;
        [XmlAttribute("userRole")]
        public string UserRole;
        [XmlAttribute("channelID")]
        public string ChannelId;
    }
    [Serializable]
    public class Message
    {
        public Message()
        {     }
        [XmlAttribute("id")]
        public string Id;
        [XmlAttribute("dateTime")]
        public string DateTime;
        [XmlAttribute("userID")]
        public string UserId;
        [XmlAttribute("userRole")]
        public string UserRole;
        [XmlAttribute("channelID")]
        public string ChannelId;
        [XmlElement("username")]
        public string Username;
        [XmlElement("text")]
        public string Text;
    }
    [Serializable, XmlRoot("root")]
    public class Root
    {
        public Root()
        { }
        [XmlElement("infos")]
        public object Infos;
        [XmlArray]
        [XmlArrayItem(ElementName = "user", Type=typeof(User))]
        public User[] users;
        // define what type message is - XmlArray
        // each item within is of c# type Message but within xml file it's message
        [XmlArray]
        [XmlArrayItem(ElementName = "message", Type = typeof(Message))]
        public Message[] messages;
    }
