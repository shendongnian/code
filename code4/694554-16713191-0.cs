        protected override void Initialize(RequestContext requestContext)
        {
            // Add the User's ID if is not present in the request
            string user = requestContext.HttpContext.Request.QueryString["UniqueStudentReference"];
            if (user == null)
            {
                string userId = Various.GetGivenNameUser();
                requestContext.HttpContext.Response.RedirectToRoute(new { UniqueStudentReference = userId });
            }
            base.Initialize(requestContext);
        }
