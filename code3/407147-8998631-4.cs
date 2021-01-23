    public class Customer
    {
        public string City { get; private set; }
    
        public bool SetCity(string customerCity)
        {
            //validate that the customerCity is a valid USA city or else throw some business rule exception, and then call below code
            City = customerCity
        }
    }
