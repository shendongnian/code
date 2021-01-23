    public class AccountController
    {
        public AccountController(ICustomerRepository customerRepo, IOrderRepository orderRep)
        {
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
        }
        public void SomeActionMethod(Foo someParams)
        {
            var utility = new CustomerOrderBuilderUtility(_customerRepo, _orderRepo);
            var customerWithOrders = utility.GetCustomerAndOrders(someParams.CustomerId);
            // some domain logic...
        }
    }
