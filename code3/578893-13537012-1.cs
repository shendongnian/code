    public class User : IUser {
        public int ID { get; protected set; }
        public string Username { get; set; }
        public UserStatus Status { get; set; }
    }
