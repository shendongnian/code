    public class MyClass 
       : MyBaseClass
       , IMvxServiceConsumer
    {
        // ...
        private bool DoStuff(Action stuff)
        {
            var dispatcherProvider = this.GetService<IMvxMainThreadDispatcherProvider>();
            var dispatcher = dispatcherProvider.Dispatcher;
            if (dispatcher == null) {
               return false;
            }
            return dispatcher.RequestMainThreadAction(action);
        }
     }
