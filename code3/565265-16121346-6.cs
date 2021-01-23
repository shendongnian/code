    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DriversLicense License;
    }
    
    // An instance of this type will be part of the object graph and will need to be 
    // serialized also.
    public class DriversLicense
    {
        public string Number { get; set; }
    }
