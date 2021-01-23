    class CustomerBusinessConsumer : ICustomerBusinessConsumer
    {
        private readonly ICustomerBusiness customerBusiness;
    
        public CustomerBusinessConsumer(ICustomerBusiness customerBusiness)
        {
            this.customerBusiness = customerBusiness;
        }
        ...
    }
