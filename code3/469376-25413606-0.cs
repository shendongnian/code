    public class CustomerController : ApiController {
      private ICustomerContext repo;
      public CustomerController(ICustomerContext repo) {
        this.repo = repo;
      }
      public HttpResponseMessage Get(int id) {
        Customer customer = getCustomer(id);
        
        return Request.CreateResponse(customer);
      }
      private Customer getCustomer(int id){
        .....do some work
        .....we have a problem so throw exception
        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, "Id out of range");
        return repo.Customers.SingleOrDefault(c=>c.CustomerID == id)
    }
