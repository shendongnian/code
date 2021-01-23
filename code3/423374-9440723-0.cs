    [Serializable()]
    [XmlType()]
    public class UserAccount
    {
        [XmlElement()]
        public string UserName { get; set; }
        [XmlElement()]
        public string Password { get; set; }
        [XmlElement()]
        public bool HasAdminRights { get; set; }
        [XmlElement()]
        public int LoginAttempts { get; set; }
    }
