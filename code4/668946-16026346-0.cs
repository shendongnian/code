    // "Module User" was decoupled from "module", by coding it against module's interface:
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
            
        // dependency injection constructor
        public CustomerController(
    			...
    			ICustomerRepository customerRepository,
    			...)
        {
                _customerRepository = customerRepository;
        }
    
    
        public ActionResult Details(Nullable<Guid> id)
        {
                Customer c = _customerRepository.GetByKey(id.Value.ToString());
                ...
        }
    
        ...
    } 
