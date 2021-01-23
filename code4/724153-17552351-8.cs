    public class RequireRolePolicyViolationHandler : IPolicyViolationHandler
    {
        public ActionResult Handle(PolicyViolationException exception)
        {
            //return new HttpUnauthorizedResult(exception.Message);
            return
                new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "Test", controller = "Account"})); //Created a view for testing
        }
    }
