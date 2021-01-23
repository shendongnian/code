    // First the Interface, things in here decorated with the Operation contract gets exposed, things with serializable are available to the client
    namespace MyService
    {
        [ServiceContract]
        public interface ICustomer
        {
            [OperationContract]
            int GetBalance(Guid CustomerId);
        }
    
        [Serializable]
        public class Customer
        {
            public Guid Id;
            public int Balance;
        }
    }
    // 2nd class file is the code mapping to the interface
    namespace MyService
    {
        private List<Customer> Customers = new List<Customer>();
        public class MyService : ICustomer
        {
            public int GetBalance(Guid CustomerId)
            {
                foreach(Customer c in Customers)
                {
                     if(c.Id == CustomerId)
                     {
                         return c.Balance;
                     }
                }
            }
        }
    }
