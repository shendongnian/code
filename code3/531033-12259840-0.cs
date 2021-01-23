    public class WcfCustomerCreditServiceClient
        : ICustomerCreditServiceClient
    {
        public CreditLimit GetCreditLimit(Customer customer)
        {
            using (var service = new CustomerCreditServiceClient())
            {
                return service.GetCreditLimit(customer.Firstname,
                    customer.Surname, customer.DateOfBirth);       
            }
        }
    }
