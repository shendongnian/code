            container
                .RegisterType<IRepository, Repository>()
                .RegisterType<IGateway, Gateway>("FooGateway", new InjectionConstructor("I am foo"))
                .RegisterType<IGateway, Gateway>("BarGateway", new InjectionConstructor("I am bar"))
                .RegisterType<IServiceFoo, Service>(new InjectionConstructor(new ResolvedParameter<IRepository>(), typeof(IGateway)))
                .RegisterType<IServiceBar, Service>(new InjectionConstructor(new ResolvedParameter<IRepository>(), typeof(IGateway)));
            var barGateway = container.Resolve<IGateway>("BarGateway");
            var fooGateway = container.Resolve<IGateway>("FooGateway");
            var serviceBar = container.Resolve<IServiceBar>(new ParameterOverride("gateway", barGateway));
            var serviceBarGatewayName = serviceBar.DoSomething();
            var serviceFoo = container.Resolve<IServiceBar>(new ParameterOverride("gateway", fooGateway));
            var serviceFooGatewayName = serviceFoo.DoSomething();
            Assert.AreEqual("I am bar", barGateway.Name); // pass
            Assert.AreEqual("I am foo", fooGateway.Name); // pass
            Assert.AreEqual("I am bar", serviceBarGatewayName); // pass
            Assert.AreEqual("I am foo", serviceFooGatewayName); // pass
