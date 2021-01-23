    public abstract class Person
    {
        public virtual string FirstName {get;set;}
    
        public virtual string LastName {get;set;}
    }
    public class Employee : Person
    {
        [Required]
        [Display(Description = "Employee First Name", Name = "Employee First Name")]
        public override string FirstName {get;set;}
    
        [Required]
        [Display(Description = "Employee Last Name", Name = "Employee Last Name")]
        public override string LastName {get;set;}
    
        public int NumberOfYearsWithCompany {get;set;}
    }
    
    public class Client : Person
    {
        [Required]
        [Display(Description = "Your first Name", Name = "Your first Name")]
        public override string FirstName {get;set;}
    
        [Display(Description = "Your last Name", Name = "Your last Name")]
        public override string LastName {get;set;}
    
        [Display(Description = "Company Name", Name = "What company do you work for?")]
        public string CompanyName {get;set;}
    }
