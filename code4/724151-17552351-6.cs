    public class RequireRolePolicyViolationHandler : IPolicyViolationHandler
    {
        public ActionResult Handle(PolicyViolationException exception)
        {
            //Make sure you're redirecting to the desired page here. You should put a stop here to debug it and see if it's being hit. 
            return new HttpUnauthorizedResult(exception.Message);
        }
    }
