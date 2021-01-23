    [HttpGet]
    public List<Customer> Get()
    {
        //gets all customer
    }
    [ActionName("CurrentMonth")]
    public List<Customer> GetCustomerByCurrentMonth()
    {
        //gets some customer on some logic
    }
    [ActionName("customerById")]
    public Customer GetCustomerById(string id)
    {
        //gets a single customer using id
    }
    [ActionName("customerByUsername")]
    public Customer GetCustomerByUsername(string username)
    {
        //gets a single customer using username
    }
