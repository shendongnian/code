    public class FailureHandlingMechanism
    {
      _handlers = Dictionary<Type, IFailureHandling>();
    
      public FailureHandler(Dictionary<Type, IFailureHandling> handlers)
      {
        _handlers = handlers;
      }
    
      public void Handle(Exception e)
      {
        //might add some checking whether key is in dictionary
        _handlers[e.GetType()].Perform();
      }
    }
