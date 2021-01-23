    public class UserBase {
      public int Id {get;set}
      public string Name {get;set;}
    }
    public class User : UserBase {
      public IEnumerable<Image> Images { get; set; }
    }
    //or using interface, I think this is better
    public class IUserBase {
      int Id {get;set}
      string Name {get;set;}
    }
    public class User : IUserBase {
      public int Id { get; set; }
      public string Name { get; set; }
      public IEnumerable<Image> Images { get; set; }
    }
