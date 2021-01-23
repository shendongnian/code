    public class Role
    {
    
        [Key]
        public int RoleId { get; set; }
    
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    
        public ICollection<User> AssignedUsers { get; set; }
    
    }
     public class User
    {
    
        [Key]
        public int UserId { get; set; }
    
        [Required]
        public Int32 CompanyId { get; set; }
    
        [Required]
        public String UserName { get; set; }
    
        public String Password { get; set; }
    
        public String PasswordSalt { get; set; }
    
        public String Email { get; set; }
    
        public Boolean IsApproved { get; set; }
    
        public Boolean IsLockedOut { get; set; }
    
        public DateTime CreateDate { get; set; }
    
        public DateTime LastLoginDate { get; set; }
    
        public DateTime LastPasswordChangedDate { get; set; }
    
        public DateTime LastLockoutDate { get; set; }
        
        public ICollection<Role> Roles{ get; set; }
    }
