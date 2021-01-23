    public class User
    {
            [Key]
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public virtual Profile Profile { get; set; }
    }
    
    public class Profile
    {
            [Key]
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [Required]
            public virtual User User { get; set;}
    }
