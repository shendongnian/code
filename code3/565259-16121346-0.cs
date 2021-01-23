    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DriversLicense License;
    }
    
    /// <summary>
    /// Interrelated objects are all used to form an object graph, and need
    /// to be serialized too.
    /// </summary>
    public class DriversLicense
    {
        public string Number { get; set; }
    }
