        container.RegisterType<ITestClass, TestClass1>("TestClass1");
        container.RegisterType<ITestClass, TestClass2>("TestClass2");
        var class0 = new TestClass3();
        container.RegisterInstance<ITestClass>(class0);
        var class1 = container.Resolve<TestClass1>();
        var class2 = container.Resolve<TestClass2>();
        var class3 = container.Resolve<ITestClass>("TestClass1");
        var class4 = container.Resolve<ITestClass>("TestClass3");
