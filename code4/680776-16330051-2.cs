    [XmlRoot("myRoot")]
    public class Users {
      [XmlElement("User")]
      public List<User> UserList {get;set;}
    }    
    public class User {
      [XmlElement("Name")]
      public string FirstName {get;set;}
    }
