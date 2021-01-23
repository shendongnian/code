    public class Person
        {
            public string GivenName { get; set; }
            public string Surname { get; set; }
            public ContactInfo ContactInformation { get; set; }
        }
    public class Applicant : Person
        {
            public Person Spouse { get; set; }
            public List<Person> Children { get; set; }
            public List<Reference> References { get; set; }
        }
    public class ContactInfo
        {
            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
    
            [DataType(DataType.EmailAddress)]
            public string EmailAddress { get; set; }
    
            public Address PrimaryAddress { get; set; }
            public Address AlternativeAddress { get; set; }
        }
