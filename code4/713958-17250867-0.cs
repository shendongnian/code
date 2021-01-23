    public class Object
    {
        [Key]
        public int ObjectID{ get; set; }
        public List<User> Users { get; set; }
    }
    public class User
    {
        [Key]
        public int UserID{ get; set; }
        public List<Object> Objects { get; set; }
    }
