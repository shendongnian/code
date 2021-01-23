     public class DefaultController : ApiController
    {
        
        public HttpResponseMessage PutDataResponse(string firstName, string lastName, int age)
        {
            string msg =  "Updated: First name: " + firstName +
                " | Last name: " + lastName +
                " | Age: " + age;
            return Request.CreateResponse(HttpStatusCode.OK, msg);
        }
    }
