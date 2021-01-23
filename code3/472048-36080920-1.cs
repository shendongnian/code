    public class DRFValidationFilters : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                //BadRequest(actionContext.ModelState);
            }
        }
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => {
                if (!actionContext.ModelState.IsValid)
                {
                    actionContext.Response = actionContext.Request
                         .CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);                    
                }
            });
           
        }
    public class AspirantModel
    {
        public int AspirantId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }        
        public string LastName { get; set; }
        public string AspirantType { get; set; }       
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string MobileNumber { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int CenterId { get; set; }
    }
  
        [HttpPost]
        [Route("AspirantCreate")]
        [DRFValidationFilters]
        public IHttpActionResult Create(AspirantModel aspirant)
        {
                if (aspirant != null)
                {
                }
                else
                {
                    return Conflict();
                }
              return Ok();
            
        }
