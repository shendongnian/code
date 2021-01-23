    public class User
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        [CustomProperty]
        public UserGroup Group { get; set; }
    }
