    public class User
    {   
        public int Id { get; set; }
        
        [Column(TypeName = "DateTime2")]
        public virtual DateTime CreatedDateTime { get; set; }
    
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual string AccessToken { get; set; }
        public virtual string Name { get; set; }
    }
