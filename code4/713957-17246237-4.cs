    public class Object
    {
        public int ObjectID                    { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    public class User
    {
        public int UserID                          { get; set; }
        public virtual ICollection<Object> Objects { get; set; }
    }
