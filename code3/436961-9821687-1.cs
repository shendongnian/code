    public class SomeFactory : ISomeFactory
    {
        public SomeFactory(IContainer sontainer) { this.container = container; }
        ISomeDependency CreateSomeDependency() { this.container.GetInstance<ISomeDependency>(); }
    }
