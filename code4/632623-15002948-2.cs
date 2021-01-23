    class UserStatus
    {
        public string Username { get; set; }
        public string Status { get; set; }
        public override bool Equals(object obj)
        {
            UserStatus other = obj as UserStatus;
            return other != null && other.Username == Username && other.Status == Status;
        }
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17;
                hash = hash * 31 + Username == null ? 0 : Username.GetHashCode();
                hash = hash * 31 + Status == null ? 0 : Status.GetHashCode();
                return hash;
            }
        }
    }
