     class ApiActionSelector : IHttpActionSelector
        {
            private readonly IHttpActionSelector defaultSelector;
    
            public ApiActionSelector(IHttpActionSelector defaultSelector)
            {
                this.defaultSelector = defaultSelector;
            }
            public ILookup<string, HttpActionDescriptor> GetActionMapping(HttpControllerDescriptor controllerDescriptor)
            {
                return defaultSelector.GetActionMapping(controllerDescriptor);
            }
            public HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
            {
                // Get HttpMethod from current context
                HttpMethod httpMethod = controllerContext.Request.Method;
    
                // Set route values for API
                controllerContext.RouteData.Values.Add("action", httpMethod.Method);
    
                // Invoke Action
                return defaultSelector.SelectAction(controllerContext);
            }
        }
