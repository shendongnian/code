    namespace ParameterSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Customer customer = null;
                GetValue(customer);
                Console.WriteLine("In Main Method : Is customer Null? >>  " + (customer == null));
                Console.Read();
            }
            public static void GetValue(Customer customer)
            {
                customer = new Customer();
                Console.WriteLine("Inside GetValue Method : Is customer Null ? >>  " + (customer == null));
            }
        }
        class Customer
        { }
    }
