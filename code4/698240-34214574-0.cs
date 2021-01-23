    public class MyClass
    {
        public int EmployeeID { get; set; }
    
        [RelatedProperty(nameof(EmployeeID))]
        public int EmployeeNumber { get; set; }
    }
