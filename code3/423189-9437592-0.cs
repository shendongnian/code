    [Test]
    public void NamedDependenciesTest()
    {
        IUnityContainer container = new UnityContainer();
        container.RegisterType<IInputService, ConsoleInputService>();
        container.RegisterType<IOutputService, ConsoleOutputService>("Console");
        container.RegisterType<IOutputService, MessageBoxOutputService>("Window");
        container.RegisterType<ICalculator>("Cal1", new InjectionFactory((c) => new Calculator(c.Resolve<IInputService>(), c.Resolve<IOutputService>("Console"))));
        container.RegisterType<ICalculator>("Cal2", new InjectionFactory((c) => new Calculator(c.Resolve<IInputService>(), c.Resolve<IOutputService>("Window"))));
        // alternative setup with ResolvedParameter:
        //container.RegisterType<ICalculator, Calculator>("Cal1", new InjectionConstructor(new ResolvedParameter(typeof(IInputService)), new ResolvedParameter(typeof(IOutputService), "Console")));
        //container.RegisterType<ICalculator, Calculator>("Cal2", new InjectionConstructor(new ResolvedParameter(typeof(IInputService)), new ResolvedParameter(typeof(IOutputService), "Window")));
        var cal1 = container.Resolve<ICalculator>("Cal1");
        Assert.IsInstanceOf<ConsoleOutputService>(cal1.OutputService);
        var cal2 = container.Resolve<ICalculator>("Cal2");
        Assert.IsInstanceOf<MessageBoxOutputService>(cal2.OutputService);
    }
    interface IInputService { }
    interface IOutputService { }
    interface ICalculator { IOutputService OutputService { get; } }
    class ConsoleInputService : IInputService { }
    class ConsoleOutputService : IOutputService { }
    class MessageBoxOutputService : IOutputService { }
    class Calculator : ICalculator
    {
        public Calculator(IInputService input, IOutputService output) { this.InputService = input; this.OutputService = output; }
        public IInputService InputService { get; private set; }
        public IOutputService OutputService { get; private set; }
    }
