    public interface IUser {
      public string Name { get; }
      // etc...
    }
    
    public class User : IUser {
      public string Name { get; set; }
      // etc...
    }
    
    public class OldUser : IUser {
      public string Name { get; set; }
      // rest of IUser
      public DateTime? LastSeenOn { get; set; }
    }
