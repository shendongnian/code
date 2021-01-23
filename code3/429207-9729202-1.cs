    interface IInterfaceAAndB : IInterfaceA, IInterfaceB
    
    interface ISomeWcfContract
    {
        IInterfaceA GetA();
        IInterfaceB GetB();
        IInterfaceAAndB GetAAndB();
    }
    
    class ClientImplementationOfA : IInterfaceA
    class ClientImplementationOfB : IInterfaceB
    class ClientImplementationOfAAndB : IInterfaceAAndB
    
    private static IEnumerable<Type> GetKnownType()
    {
        yield return typeof(ClientImplementationOfA);
        yield return typeof(ClientImplementationOfB);
        yield return typeof(ClientImplementationOfAAndB);
    }
