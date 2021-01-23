    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            this.Games = new HashSet<Game>();            
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Balance { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
