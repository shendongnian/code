    public class User
    {
        public int Id { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
    public class CustomUser : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
    }
    public class UserDetail
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public virtual User User { get; set; }
    }
