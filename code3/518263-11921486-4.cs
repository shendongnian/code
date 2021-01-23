        public MainPage()
        {
            var container = (DependencyContainer) HttpContext.Current.Application["container"];
            this.customerBusinessConsumer = container.ResolveCustomerBusinessConsumer();
        }
