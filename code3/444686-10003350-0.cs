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
