    public class ParentViewModel
    {
        public UserViewModel User {get; set; }
        
        //....
    }
    public class UserViewModel 
    {
        [Remote("UniqueUsername", "Validation")]
        public string Username { get; set; }
        
        //....
    }
