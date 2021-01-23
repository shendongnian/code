    class TwoUsersKey
    {
        public string User0 { get; set; }
        public string User1 { get; set; }
        public bool Equals(TwoUsersKey obj)
        {
            return (this.User0 == obj.User0 && this.User1 == obj.User1)
                || (this.User0 == obj.User1 && this.User1 == obj.User0);
        }
        public override int GetHashCode()
        {
            return User0.GetHashCode() ^ User1.GetHashCode();
        }
    }
