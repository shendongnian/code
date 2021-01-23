    public class BaseEvent { }
    
    public class MyFirstEvent : BaseEvent { }
    
    public class MySecondEvent : BaseEvent { }
    
    public class MyThirdEvent : BaseEvent { }
    
    
    public interface ICallbacks
    {
      [OperationContract(IsOneWay = true)]
      void EventHandler(BaseEvent myEvent);
    }
    
    public class MyService : ICallbacks
    {
       public void EventHandler(BaseEvent myEvent)
       {
          //Now you can check for the concrete type of myEvent and jump to specific method.
          //e.g.: 
          if (myEvent is MyFirstEvent)
          {
             //Call your handler here.
          }
    
    
          //Another approach can be predefined dictionary map of your event handlers
          //You want to define this as static map in class scope, 
          //not necessarily within this method.
          Dictionary<Type, string> map = new Dictionary<Type, string>()
          {
             { typeof(MyFirstEvent), "MyFirstEventHandlerMethod" },
             { typeof(MySecondEvent), "MySecondEventHandlerMethod" }
             { typeof(MyThridEvent), "MyThirdEventHandlerMethod" }
          };
    
          //Get method name from the map and invoke it.
          var targetMethod = map[myEvent.GetType()];
          this.GetType().GetMethod(targetMethod).Invoke(myEvent);
       }
    }
