    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        // and other methods you'd like to use
    }
    public sealed class CustomerService : ICustomerService
    {
        private DbContext context = new DbContext();
        // or, alternatively, even something along these lines
        private DbContext context;
        public CustomerService()
        {
            context = ContextFactory.GetDBContext();
        }
        //----
        public IEnumerable<Customer> GetAllCustomers()
        {
             // here goes the implementation
        }
    }
    public class YourController : Controller
    {
        private ICustomerService customerService;
        public YourController(ICustomerService service)
        {
              customerService = service;
        }
        // and now you can call customerService.GetAllCustomers() or whatever other methods you put in the interface. 
    }
