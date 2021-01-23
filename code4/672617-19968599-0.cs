    public class EmployeeModel 
    {
        [Required]
        [UniqueEmailAddress]
        public string EmailAddress {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int OrganizationId {get;set;}
    }
    
