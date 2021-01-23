      public class User
        {
            public Customer Customers;
    
            public string UserName { get; set; }
        }
    
        public class Customer
        {
            public string DisplayName { get; set; }
    
            public string OriginalValue { get; set; }
        }
