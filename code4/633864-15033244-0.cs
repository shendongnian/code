    public class User
    {
            [Key]
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public int ProfileID { get; set; }
            [ForeignKey("ProfileID")]
            public virtual Profile Profile { get; set; }
    }
    
    public class Profile
    {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
    }
