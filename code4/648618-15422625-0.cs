    public static RouteController GetRouteController(string useragent)
            {
                var controller = new RouteController();
                var builder = new TestControllerBuilder();
    
                builder.InitializeController(controller);
                //mock out the useragent string
                controller.HttpContext.Request.Stub(r => r.UserAgent).Return(useragent);
                return controller;
            }
