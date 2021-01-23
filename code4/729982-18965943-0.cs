    public class WrapperController : ApiController
    {
        // POST api/wrapper
        public void Post(ComplexWithChild value)
        {
            var other = value.otherdata;
            var childcontroller = new ChildController();
            childcontroller.Post(value.child); // ChildController is not initialized, and has null Request
            /*inside ChildController...// causes null reference exception due to null Request
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "my message"); 
            */
            childcontroller.Request = this.Request;
            childcontroller.Post(value.child); // ChildController uses same Request
            /*inside ChildController...// this works now
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "my message"); 
            */
        }
    }
    public class ChildController : ApiController
    {
        public void Post(Child value)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "my message"));
        }
    }
