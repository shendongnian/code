    public class SignUpModel
    {
        public string AccountType { get; set; }
        public Common Common { get; set; }
        public Company Company { get; set; }
        public Personal Personal { get; set; }
    }
    
    
    public class Company
    {
        [Required]
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
    
    public class Personal
    {
        [Required]
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
    
    public class Common
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Passwrod { get; set; }
    }
