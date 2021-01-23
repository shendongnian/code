    public class Person
    {
        public String Name { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public DateTime Birthday { get; set; }
        public BirthCertificate? BirthCertificate { get;set; }
        public MarriageCertificate? MarriageCertificate { get;set; }
        // ...etc...
    }
    public class Certificate
    {
        public String Code { get;set; }
        public DateTime IssueDate { get;set; }
        // ...etc...
    }
    
    public class BirthCertificate: Certificate
    {
        public DateTime BirthDate { get;set; }
        // ...etc...
    }
    
    public class MarriageCertificate: Certificate
    {
        public String SpouseName { get;set; } // or Spouse could also be a person
        // ...etc...
    }
    
    public class Employee
    {
        public ISet<Person> Children { get; }
        // ...etc...
    }
