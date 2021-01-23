    var developerFactory = container.Resolve<IDeveloperFactory>();
    using (container.BeginScope())
    {
        var developer = developerFactory.Create("John"); // this creates a new Developer and caches it in the current scope
        var task1 = container.Resolve<ITask>();
        var task2 = container.Resolve<ITask>();
        Assert.Same(task1.Developer, task2.Developer);
        Assert.Equal("John", task1.Developer.Name);
        task1.Complete();
        task2.Complete();
        container.Release(task1);
        container.Release(task2);
    }
