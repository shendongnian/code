    abstract class User
    {
        public virtual UserType Type { get; protected set;}
        public User()
        {
            Type = Enum.Parse(typeof(UserType), this.GetType().Name);
        }
    }
