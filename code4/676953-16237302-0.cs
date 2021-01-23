    public class Employee 
    {
        [Key] public int EmpId { get; set; } // < Can I make a suggestion here
                                             // and suggest you use Id rather than
                                             // EmpId?  It looks better referring to 
                                             // employee.Id rather than employee.EmpId
        [Required] public string Fullname { get; set; }
        ...
    }
    public class AnotherClass
    {
        ...
    }
