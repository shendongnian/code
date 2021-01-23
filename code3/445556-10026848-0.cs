    public sealed class MyViewModel
    {
        public string Name {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string PhoneNumber {get; set;}
         
        public MyViewModel(Person person)
        {
            FillViewModel(person); // either copy the given properties by hand, use Automapper, or write your own simple (although quite general) mapping method using reflection
            Address = FormatString(Address);
            City = FormatString(City);
            PhoneNumber = FormatString(PhoneNumber);
        }
        public MyViewModel()
        { 
        }
    }
