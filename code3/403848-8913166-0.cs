    interface IEventRepository
    {
       void MethodA();
       void MethodB();
    }
    
    class BaseEvents : IEventRepository
    {
       public void MethodA()
       { ... }
    
       public virtual void MethodB()
       { ... }
    
       public void BaseEventsMethod()
       { ... }
    
       public void BaseEventsMethod2()
       { ... }
    }
    
    class FooBarEvents : BaseEvents
    {
       public override void MethodB()
       { 
          // now FooBarEvents has a different implementation of this method than BaseEvents
       }
    
       public new void BaseEventsMethod2()
       { 
          // this hides the implementation that BaseEvents uses
       }
    
       public void FooBarEventsMethod()
       { 
          // no overriding necessary
       }
    }
    
    // all valid calls, assuming myFooBarEvents is instantiated correctly
    myFooBarEvents.MethodA()
    myFooBarEvents.MethodB()
    myFooBarEvents.BaseEventsMethod();
    myFooBarEvents.BaseEventsMethod2();
    myFooBarEvents.FooBarEventsMethod();
