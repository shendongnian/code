    XmlSerializer ser = new XmlSerializer(typeof(Users));
    var u = (Users)ser.Deserialize(stream);
    [XmlRoot("users")]
    public class Users
    {
        [XmlElement("user")]
        public User[] UserList { get; set; }
    }
    public class User
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlArray("orders"),XmlArrayItem("order")]
        public Order[] OrderList { get; set; }
    }
    [XmlRoot("order")]
    public class Order
    {
        [XmlElement("number")]
        public string Number { get; set; }
    }
