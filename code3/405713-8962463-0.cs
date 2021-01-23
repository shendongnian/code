    public class Customer
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
    public class Program
    {
        private List<Customer> _customers = new List<Customer();
        public Program()
        {
            _customers.Add(new Customer() 
            { 
                Name = "A", Telephone="1" 
            });
        }
        // your other methods here - like View()
    }
