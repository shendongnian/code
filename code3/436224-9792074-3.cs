    public class User
    {
         public string LastName {get;set;}
         public string FirstName {get;set;}
         public string EMail {get;set;}
    }
    public static User GetUser(string username, string password)
    { 
        // Some process that determines strings values based on supplied parameters
        return new User() {FirstName=fn, LastName=ln, EMail=em};
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = GetUser(username,password);
    }
