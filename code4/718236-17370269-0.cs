    public class TicketRedirectResult : RedirectToRouteResult 
    {
        public override void ExecuteResult(ControllerContext context)
        {
            string destinationUrl = UrlHelper.GenerateUrl(
                RouteName, 
                null /* actionName */, 
                null /* controllerName */, 
                //Only return the ticket id, not the entire dictionary
                new RouteValueDictionary(new { ticketid = RouteValues["ticketid"] }), 
                Routes, 
                context.RequestContext, false /* includeImplicitMvcValues */);
            // snip other code
        }
    }
