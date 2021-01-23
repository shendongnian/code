    public enum UserStatus { Approved, Disabled }
    public interface IUser {
        public int ID { get; }
        public string Username { get; set;}
        public UserStatus Status { get; set;}
    }
