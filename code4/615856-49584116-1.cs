    public class ValuesController : ApiController
    {
       
        [HttpPost]
        public string GetCustomer([FromBody] RequestModel req)
        {
            return "Customer";
        }
        [HttpPost]
        public string GetCustomerList([FromBody] RequestModel req)
        {
            return "Customer List";
        }
    }
