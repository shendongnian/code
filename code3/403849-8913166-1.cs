    interface IEventRepository
    {
       void CommonMethodA();
       void CommonMethodB();
       void ImplentationSpecificMethod();
    }
    
    abstract class BaseEvents : IEventRepository
    {
       public void CommonMethodA()
       { ... }
    
       public virtual void CommonMethodB()
       { ... }
       public abstract void ImplementationSpecificMethod();
    
       public void BaseEventsMethod()
       { ... }
    
       public void BaseEventsMethod2()
       { ... }
    }
    
    class FooBarEvents : BaseEvents
    {
       public override void CommonMethodB()
       { 
          // now FooBarEvents has a different implementation of this method than BaseEvents
       }
       public override void ImplementationSpecificMethod()
       { 
          // this must be implemented
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
    // use the contract thusly:
    void DoSomethingWithAnEventRepository(BaseEvents events)
    { ... }
