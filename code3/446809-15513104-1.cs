    public class Group
        { 
        [Key]
        public int GroupID { get; set; }
    
        [Required]
        public string GroupName { get; set; }
    
        public List<User> Users { get; set; }
    }
    
    
    public class User
    {
        [Key]
        public int UserID { get; set; }
    
        [Required]
        [StringLength(20)]
    
        public string UserName { get; set; }
    
        [Required]
        public string Password { get; set; }
       
        public List<Group> Groups { get; set; }
    }
