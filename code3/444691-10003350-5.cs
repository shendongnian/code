    delegate void OnEventDelegate(kEvents anEvent);
    public class MyEventObservable
    {
        public event OnEventDelegate OnEvent;
    }
    
    public class MyEventObserver
    {
        // Constructors and all
        // ...
        public void OnEventReceived(kEvents anEvent)
        {
            switch(anEvent)
            {
                // switch through all the events and handle the ones that you need
            }
        }
    }
    MyEventObserver observer = new MyEventObserver();
    MyEventObservable observable = new MyEventObservable();
    observable.OnEvent += new OnEventDelegate(observer.OnEventReceived);
