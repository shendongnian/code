    class bootstrapper
    {
        Initialize(DependencyResolver container)
        {
            var parser = new OrderParser(container.Resolve<IOrderRepository>());
            parser.DoWork();
        }
    }
