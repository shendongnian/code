    public class User
    {
       private string _name;
       public string UserName { get; set; }       
       public List<int> ControlNumber { get; set; }
       public User (string username)
       {
           _name = username;
           ControlNumber = new List<int>();
       }
       public User()
       {
           ControlNumber = new List<int>();
       }
    
    }
