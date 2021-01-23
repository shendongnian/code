    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        // ...
        public UserProfile Referer { get; set; } // EF will generate Referer_UserId
    }
