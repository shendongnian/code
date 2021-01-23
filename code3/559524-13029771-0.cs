    public class User
    {
        private IList<UserInRole> _roles = new List<UserInRole>(); 
        
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string UsernameLowercase { get { return Username.ToLowerInvariant(); } }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var otherUser = obj as User;
            return (0 == string.CompareOrdinal(UsernameLowercase, otherUser.UsernameLowercase));
        }
        public override int GetHashCode()
        {
            return UsernameLowercase.GetHashCode();
        }
        protected virtual IList<UserInRole> Roles
        {
            get { return _roles; }
            set
            {
                value.ThrowIfNull("value");
                _roles = value;
            }
        } 
    }
