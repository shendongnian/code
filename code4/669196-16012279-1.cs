    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class UserDTO
    { 
        // Hide the UserID
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
