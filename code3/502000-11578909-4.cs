    class A : IDisposable
    {
       public event EventHandler EventHappened
       {
          add 
          {
             eventTable["EventHappened"] = (EventHandler)eventTable["EventHappened"] + value;
          }
          remove
          {
             eventTable["EventHappened"] = (EventHandler)eventTable["EventHappened"] - value; 
          }
       }
       public void Dispose()
       {
          //Amit: If you have only one event 'EventHappened', 
          //you can clear up the subscribers as follows
          eventTable["EventHappened"] = null;
          //Amit: EventHappened = null will not work here as it is 
          //just a syntactical sugar to clear the compiler generated backing delegate.
          //Since you have added 'add' and 'remove' there is no compiler generated 
          //delegate to clear
          //
          //Above was just to explain the concept.
          //If eventTable is a dictionary of EventHandlers
          //You can simply call 'clear' on it.
          //This will work even if there are more events like EventHappened          
       }
    }
    
    class B
    {          
       public B(A a)
       {
          a.EventHappened += new EventHandler(this.HandleEventB);
          //You are absolutely right here.
          //class B does not store any reference to A
          //Subscribing an event does not add any reference to publisher
          //Here all you are doing is calling 'Add' method of 'EventHappened'
          //passing it a delegate which holds a reference to B.
          //Hence there is a path from A to B but not reverse.
       }
       public void HandleEventB(object sender, EventArgs args)
       {
       }
    }
    class C
    {          
       public C(A a)
       {
          a.EventHappened += new EventHandler(this.HandleEventC);
       }
       public void HandleEventC(object sender, EventArgs args)
       {
       }
    }
    class Service
    {       
        A _a;
    
        void Start()
        {
           CustomNotificationSystem.OnEventRaised += new EventHandler(CustomNotificationSystemHandler)
        
           _a = new A();
    
           //Amit:You are right all these do not store any reference to _a
           B b1 = new B(_a);
           B b2 = new B(_a);
           C c1 = new C(_a);
           C c2 = new C(_a);
        }
    
        void CustomNotificationSystemHandler(args)
        {
            //Amit: You decide that _a has lived its life and must be disposed.
            //Here I assume you want to dispose so that it stops firing its events
            //More on this later
            _a.Dispose();
    
            //Amit: Now _a points to a brand new A and hence previous instance 
            //is eligible for collection since there are no active references to 
            //previous _a now
            _a = new A();
        }    
    }
