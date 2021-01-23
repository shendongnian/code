    public class Foo
    {
        [Key]
        public string DictionaryKey { get; set; }
    
        public string EmployeeId { get; set; }
    
        public string EmployeeLeaveEntitlementId { get; set; }
     
    }
    
    public class Employee
    {
        // other properties
    
        public ICollection<Foo> Foos { get; set; }     
    }
