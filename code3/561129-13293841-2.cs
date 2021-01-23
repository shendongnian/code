      public class CustomAutorizeAttribute : AuthorizeAttribute
            {
                public Guid ActionId { get; set; }
        
                protected override bool AuthorizeCore(HttpContextBase httpContext)
                {
                    //Check user has access to action with ID = ActionId
                    //implementation omitted
                }
            }
