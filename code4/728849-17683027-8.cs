    interface IContact
    {
        IAddress address { get; set; }
    }
    
    interface IAddress
    {
        string city { get; set; }
    }
    
    class Person : IPerson
    {
        public IContact contact { get; set; }
    }
    
    class Test {
      public void Main() {
        var contact = new Person().contact;
        var address = contact.address;
        var city = address.city;
        Console.WriteLine(city);
      }
    }
