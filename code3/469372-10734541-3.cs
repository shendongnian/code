    public class CustomerController : ApiController {
      private ICustomerContext repo;
      public CustomerController(ICustomerContext repo) {
        this.repo = repo;
      }
      
      public HttpResponseMessage Post(Customer customer) {
        repo.Add(customer);
        repo.SaveChanges();
        var response = Request.CreateResponse(HttpStatusCode.Created, customer);
        response.Headers.Location = new Uri(Request.RequestUri, string.format("customer/{0}", customer.id));
        return response;
      }
    }
