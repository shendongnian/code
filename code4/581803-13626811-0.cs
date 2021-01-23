    public class User
    {
        public virtual int Id { get; set; }
        public virtual ICollection<Photo> Photos { get; private set; }
    }
    public class Photo
    {
        public User Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual byte[] Data { get; set; }
    }
