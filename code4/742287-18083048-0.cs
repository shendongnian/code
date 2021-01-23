    public interface IInterfaceToCompose
    {
        string MethodToCreate();
    }
    [Export(typeof(IInterfaceToCompose))]
    public class ConcreteImplementation1 : IInterfaceToCompose
    {
        public string MethodToCreate()
        {
            return "Implementation 1";
        }
    }
    [Export(typeof(IInterfaceToCompose))]
    public class ConcreteImplementation2 : IInterfaceToCompose
    {
        public string MethodToCreate()
        {
            return "Implementation 2";
        }
    }
