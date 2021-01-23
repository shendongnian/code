    [HttpGet]
    [Route("api/customers/")]
    public List<Customer> Get()
    {
       //gets all customer logic
    }
    [HttpGet]
    [Route("api/customers/currentMonth")]
    public List<Customer> GetCustomerByCurrentMonth()
    {
         //gets some customer 
    }
    [HttpGet]
    [Route("api/customers/{id}")]
    public Customer GetCustomerById(string id)
    {
      //gets a single customer by specified id
    }
    [HttpGet]
    [Route("api/customers/customerByUsername/{username}")]
    public Customer GetCustomerByUsername(string username)
    {
        //gets customer by its username
    }
