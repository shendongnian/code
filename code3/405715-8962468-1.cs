    namespace MyNameSpace
    {
        public class Customer
        {
            public string Name
            {
                get;
                set;
            }
            public string Telephone
            {
                get;
                set;
            }
        }
        public class Customers
        {
            private List<Customer> customers; 
    
            public Customers()
            {
                customers = new List<Customer>();
    
                AddCustomer(new Customer() 
                { 
                Name = "A", Telephone="1" 
                });
            }
    
    
            public void RunTest()
            {
    
                Console.WriteLine();
                Console.WriteLine("****** VIDEOSTORE ******");
                Console.WriteLine();
                Console.WriteLine("1. Show Customers");
                Console.WriteLine("6. Quit");
    
                string userChoice = Console.ReadLine();
    
                switch (userChoice)
                {
                    case "1": 
                        View();
                        break;         
    
                        break;
                    case "2":
                        break;
                }
            }
    
            public void View()
            {
                foreach (Customer c in customers)
                {
                    Console.WriteLine();
                    Console.WriteLine(c.Name);
                    Console.WriteLine(c.Telephone);
                    Console.WriteLine();
                }
            }
    
            public void AddCustomer(Customer customer)                           
            {
                customers.Add(customer);          
            }
        }
    }
