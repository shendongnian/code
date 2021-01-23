    var token = controllerContext.Request.Headers.Authorization;
    if (token != null && token.Scheme.Equals("bearer", StringComparison.InvariantCultureIgnoreCase))
    {
         var ticket = Startup.OAuthOptions.AccessTokenFormat.Unprotect(token.Parameter);
         if (ticket != null && ticket.Identity != null && ticket.Identity.IsAuthenticated)
         {
              var claimsPrincipal = new ClaimsPrincipal(ticket.Identity);
              //From here, you can use the claimsPrinciple to check if user is allowed to even call the service.
              var authorized = claimsPrincipal.IsInRole("Users");
         }
     }
