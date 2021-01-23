    public class MyService : SomeExternalService
    {
        public MyService(ISomeDependency dep) : base(dep, "My Config Value") { }
    }
    // Registration
    container.Register<IService, MyService>();
