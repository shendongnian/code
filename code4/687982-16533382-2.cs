    public class Validator
    {
      private const string Username = "Carlos";
      private const string Password = "236";
    
      public bool Validate(string user, string pass) 
      {
        return (user == Username && pass == Password);
      }
    }
