    public class Person
    {
        [ObjectValidator]
        [ObjectValidator("A", Ruleset = "A")]
        public Address Address  { get; set; }
    }
    public class Address  
    {
        [StringLengthValidator(0, 32, MessageTemplate = "Invalid value '{0}' for {1}, Max length:{5}")]
        public string Address1 { get; set; }
        [StringLengthValidator(0, 32, MessageTemplate = "Invalid value '{0}' for {1}, Max length:{5}", Ruleset = "A")]
        public string Address2 { get; set; }
    }
