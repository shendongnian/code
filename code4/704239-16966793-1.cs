    public class User
    {
       private string _name;
       public string UserName { get; set; }       
       public List<int> ControlNumber { get; set; }
       public User (string username) : this()
       {
           _name = username;
       }
       public User()
       {
           ControlNumber = new List<int>();
       }
    
    }
