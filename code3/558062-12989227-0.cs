    public class Administrator
    {
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        
        private string _password;
    
        [Required]
        public string Password
        {
            get
            {
                return this._password;
            }
    
            set
            {  
                 _password = Infrastructure.Encryption.SHA256(value);                
            }
        }
    }
