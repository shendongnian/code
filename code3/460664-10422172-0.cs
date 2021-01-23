    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }       
        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<User> Following { get; set; }
    }
