    class EmailComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Email == y.Email;
        }
        public int GetHashCode(User obj)
        {
            return obj.Email.GetHashCode();
        }
    }
