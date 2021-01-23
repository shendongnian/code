    container.RegisterType<ITestClass>(new TransientLifetimeManager(),
        new InjectionFactory(
            c =>
            {
                return InitializeTest();
            }
        )
    );
