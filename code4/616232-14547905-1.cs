    [Table("Tenant")]
    public class Tenant : IEntity
    {
        private DbSet<User> _users;
        public int Id { get; set; }
        public string Name { get; set; }
        [Key]
        public string Guid { get; set; }
        public virtual ICollection<User> Users 
        {
            get 
            {
                if (_users == null)
                    _users = new List<Users>();
                return _users;
            }
            set { _users = value; }
        }
    }
