    public class User
    {
        public Guid Id { get; set; }
        // Fullname of the user account owner
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public Player Player { get; set; }
    }
    public class Player
    {
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
    }
