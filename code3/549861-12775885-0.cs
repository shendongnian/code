    public class MessageVM 
    {
        
        public string CompanyName {get;set;}
        [Required]
        public string Name {get;set;}
        public string Regarding {get;set;}
        public string Message {get;set;}
        
        [Required]
        public string Email {get;set;}
    }
