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
        Console.WriteLine(new Person().contact.address.city);
      }
    }
