    class UserStatus : IEquatable<UserStatus>
    {
        public string Username { get; set; }
        public string Status { get; set; }
        bool Equals(UserStatus  other)
        {
            return other != null && other.Username == Username && other.Status == Status;
        }
    }
