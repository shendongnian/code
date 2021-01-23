    public class User
    {
        public Badge Badge { get; set; }
    }
    public class Badge
    {
        [ScriptIgnore]
        public virtual ICollection<User> Users { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
