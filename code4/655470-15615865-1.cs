    public class Customer()
    {
        public Customer() 
        {
            this.Payment = new Dictionary<CustomerPayingMode, decimal>();
        }
        // Good practice to use a property here instead of a public field.
        public Dictionary<CustomerPayingMode, decimal> Payment { get; set; };
    }
    Customer cust = new Customer();
    cust.Payment.Add(CustomerPayingMode.CreditCard, 1M);
