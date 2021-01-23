    [RoutePrefix("api/customers")]
    public class MyController : Controller
    {
    [HttpGet]
    public List<Customer> Get()
    {
       //gets all customer logic
    }
    
    [HttpGet]
    [Route("currentMonth")]
    public List<Customer> GetCustomerByCurrentMonth()
    {
         //gets some customer 
    }
    
    [HttpGet]
    [Route("{id}")]
    public Customer GetCustomerById(string id)
    {
      //gets a single customer by specified id
    }
    [HttpGet]
    [Route("customerByUsername/{username}")]
    public Customer GetCustomerByUsername(string username)
    {
        //gets customer by its username
    }
    }
