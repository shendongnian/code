    public class CustomerData
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
    
    public class DataStore
    {
        // this is a clean description of your "deal", there's nothing behind the scenes.
        public CustomerData GetCustomerByID(int orderID)
        {
           CustomerData customer = null;
           // somehow get data from database as before using customerID
           customer = new CustomerData { Name = "John Smith", PhoneNumber = "555-123456789" };
	       return customer; 
        }
    }
