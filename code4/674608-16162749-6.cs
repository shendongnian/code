    // Not a UI component
    public class MyDomainService : IMyDomainService
    {
       private readonly IDispatcher _dispatcher;
    
       public MyDomainService(IDispatcher dispatcher) 
       {
          _dispatcher = dispatcher;
       }
    
       private void GotResultFromBackgroundThread()
       {
           _dispatcher.Dispatch(() => DoStuffOnForegroundThread());
       }
    }
