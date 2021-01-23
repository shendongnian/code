    public class User
    {
      ...
      List<Role> Roles {get; set;}
    }
    public class Role
    {
      ...
  
      List<User> Users {get; set;}
    }
