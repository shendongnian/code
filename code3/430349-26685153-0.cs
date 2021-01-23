            HttpContext.Current = MockHttpContext.FakeHttpContext();
    
            var wrapper = new HttpContextWrapper(HttpContext.Current);
            MyController controller = new MyController();
            controller.ControllerContext = new ControllerContext(wrapper, new RouteData(), controller);
            string result = controller.MyMethod();
