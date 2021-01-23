    public class DummyContext : IContext
    {
        public IKernel Kernel { get; private set; }
        public IRequest Request { get; private set; }
        public IBinding Binding { get; private set; }
        public IPlan Plan { get; set; }
        public ICollection<IParameter> Parameters { get; private set; }
        public Type[] GenericArguments { get; private set; }
        public bool HasInferredGenericArguments { get; private set; }
        public IProvider GetProvider() { return null; }
        public object GetScope() { return null; }
        public object Resolve() { return null; }
    }
