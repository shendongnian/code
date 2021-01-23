    using (IContainer nested = ObjectFactory.Container.GetNestedContainer())
    {
        var service = nested.GetInstance<IService>();
        service.DoSomething();
    }
