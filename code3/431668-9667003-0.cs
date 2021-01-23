    public class UserDetails
    {
      public static int ID { get; private set; }
      public static string Name { get; private set; }
      public static string Email { get; private set; }
    
      private static UserDetails _userDetails;
    
      private UserDetails(int id, string name, string email)
      {
        ID = id;
        Name = name;
        Email = email;
      }
    
      public static UserDetails CreateUserDetails(int id, string name, string email)
      {
        if (_userDetails != null)
        {
          throw new MyException("Second call to UserDetails.CreateUserDetails!");
        }
        _userDetails = new UserDetails(id, name, email);
    
        return _userDetails;
      }
      public static UserDetails GetUserDetails()
      {
        if (_userDetails == null)
        {
          throw new MyException("Not yet created by calling UserDetails.CreateUserDetails!");
        }
        return _userDetails;
      }
