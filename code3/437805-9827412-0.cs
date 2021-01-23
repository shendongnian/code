    public class Person
    {
        public Address HomeAddress { get; set; }
    }
    
    public class Address
    {
        public String StreetAddress { get; set; }
    }
    
    public void SomeFunc()
    {
        var person = new Person();
    
        //NullReferenceException because HomeAddress is null.
        //NOT because person is null...
        var address = person.HomeAddress.StreetAddress;
    }
