    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }
    
        public HomePhoneViewModel HomePhone { get; set; }
        public WorkPhoneViewModel WorkPhone { get; set; }
    }
    
    public class HomePhoneViewModel : PhoneViewModel 
    {
    }
    public class WorkPhoneViewModel : PhoneViewModel 
    {
    }
    public class PhoneViewModel 
    {
        public string CountryCode { get; set; }
    
        public string AreaCode { get; set; }
    
        [CustomRequiredPhone]
        public string Number { get; set; }
    }
