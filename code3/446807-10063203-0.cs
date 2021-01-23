    public class User
    {
        [Key]
        public int UserID { get; set; }
    
        [Required]
        [StringLength(20)]
    
        public string UserName { get; set; }
    
        [Required]
        public string Password { get; set; } 
     
        [ForeignKey("GroupId")]  
        public virtual Group Groups { get; set; }
    }
