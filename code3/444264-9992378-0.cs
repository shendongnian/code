    // Business layer
    public class VirtualMachineManager
    {
       IRebooter _rebooter;
       public class(IRebooter rebooter)
       {
          _rebooter = rebooter;
       }
    }
    
    // helper class
    public class Rebooter : IRebooter 
    {
       ....
    }
