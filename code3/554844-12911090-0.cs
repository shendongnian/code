    public class UserLogin
    {
        [Key]
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public byte Password { get; set; }
    }
    public class UserDetails
    {
        [Key]
        public int DetailID { get; set; }
    
        [ForeignKey("UserLogin")]
        public int UserID { get; set; }
    
        public string UserName { get; set; }
        public string Address { get; set; }
    
        //additional
        public UserLogin UserLogin { get; set; }
    }
    public class UserType
    {
        [Key]
        public int TypeID { get; set; }
        [ForeignKey("UserLogin")]
        public int UserID { get; set; }
        public string TypeName { get; set; }
        public string TypeDiscription { get; set; }
    
        //additional
        public UserLogin UserLogin { get; set; }
    }
