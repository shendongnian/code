    [ServiceContract(Session = true)]
    interface IMyContract
    {
        [OperationContract]
        void MyMethod();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    class MyService : IMyContract,IDisposable
    {
        int m_Counter = 0;
        MyService()
       {
           Trace.WriteLine("MyService.MyService()");
       }
       public void MyMethod()
       {
           m_Counter++;
           Trace.WriteLine("Counter = " + m_Counter);
        }
        public void Dispose()
        {
            Trace.WriteLine("MyService.Dispose()");
        }
    }
    
