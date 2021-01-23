    [Table(Name = "foo")]
    public class Users
    {
       [Column(Name = "user_name")]
       username {get; set;};
       [Column(Name = "user_pword")]
       password {get; set;};
       [Column(Name = "user_isonline")]
       isonline {get; set;};
    }
    public static List<Users> GetOnline() 
    { 
       List<Users> listaOnline = new List<Users>(); 
       listaOnline = ExecuteQuery("SELECT * username FROM dbuser WHERE (isonline ='1')");
       return listaOnline;
    } 
