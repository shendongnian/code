    interface IFoo
    {
        void DoSomething();
    }
    [ServiceContract]
    interface IWCFFoo
    {
        [OperationContract]
        void DoSomething();
    }
    class FooAdapter : IFoo
    {
         IWCFFoo wrapped;
 
         public FooAdapter(IWCFFoo wrapped)
         {
              this.wrapped = wrapped;
         }
         public void DoSomething()
         {
              wrapped.DoSomething(); 
         }
    }
