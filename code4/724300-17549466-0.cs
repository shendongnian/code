    public class User
    {
        public int UserId {get; set;}
        public string Info {get; set;}
    
        public virtual ICollection<UserCase> UserCase {get; set;}
    }
    public class Case
    {
        public int CaseId {get; set;}
        public string Info {get; set;}
    
        public virtual ICollection<UserCase> UserCase {get; set;}
    }
    public class UserCase
    {
        public int CaseId {get; set;}
        public int UserId {get; set;}
    
        public virtual Case Case {get; set;}
        public virtual User User {get; set;}
        
        public string UserType {get; set;}
    }
