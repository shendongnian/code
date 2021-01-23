    public class User
    {
        [Key]
        public int UserID { get; set; }
    
        [Required]
        [StringLength(20)]
    
        public string UserName { get; set; }
    
        [Required]
        public string Password { get; set; }
        public int GroupId { get; set; }
        public virtual Group Groups { get; set; }
    }
