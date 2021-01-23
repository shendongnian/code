    public class CustomerController : ApiController {
      private ICustomerContext repo;
      public CustomerController(ICustomerContext repo) {
        this.repo = repo;
      }
      
      public Customer Get(int id) {
        var customer = repo.Customers.SingleOrDefault(c=>c.CustomerID == id);
        if (customer == null) {
          throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        return customer;
      }
    }
