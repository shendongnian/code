    public class URoles {
        public bool Admin { get; set; }
        public bool Moderator { get; set; }
        public virtual User User { get; set; }
    }
    public class User {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public virtual URoles Roles { get; set; }
    }
