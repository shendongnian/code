       public class User
        {
            public int Id { get; set; }
    
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
    
            public int UserProfileId { get; set; }
    
            [ForeignKey("UserProfileId")]
            public virtual UserProfile UserProfile { get; set; }
        }
