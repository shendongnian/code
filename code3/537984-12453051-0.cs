    // This one will not be visible to COM clients.
    [ClassInterface(ClassInterfaceType.None)]
    public class MyClass1
    {
      
    }
    // This one will provide an interface for COM clients, 
    // but only when/if one is requested of it.
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class MyClass2
    {
      
    }
    // This one will, immediately upon instantiation, 
    // automatically include an interface for COM clients.
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class MyClass3
    {
      
    }
 
