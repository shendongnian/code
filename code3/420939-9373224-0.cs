    [Table("User")]
    public class User
      {
        [Key]
        public Int64 UserId { get; set; }
    
        public virtual UserRole UserRole { get; set; }
    }
    
    [Table("UserRole")]
    public class UserRole
    {
        [Key,Column(Order = 0)]
        public int RoleID { get; set; }
    
        [Key,Column(Order = 1)]
        public Int64 UserId { get; set; }
    
        public virtual User User { get; set; }
    }
