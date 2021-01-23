    interface IDailyEventBase 
    {
        void MethodOne();
    }
    class SomeEvent : IDailyEventBase ...
    class DailyEventEntity : IDailyEventBase 
    {
       IDailyEventBase inner;
       public DailyEventEntity(IDailyEventBase inner)
       {
           this.inner = inner;
       }
       public void MethodOne() 
       {
          // delegate directly to wrapped class. You can also add more code here.
          return inner.MethodOne();
       }
          
       // other methods of this class (may use properties of "inner" too)
       public void OtherMethod()...
    }
