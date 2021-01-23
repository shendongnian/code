    [RoutePrefix("api/Product")]
    public class CustomersController : ApiController
    {
        [Route("{customerName}/{customerID:int}/GetCreditCustomer")]
        public IEnumerable<uspSelectCreditCustomer> GetCreditCustomer(string customerName, int customerID)
        {
            ...
        }
