    public class MyEventObservable
    {
        private Dictionary<kEvents, List<IObserver>> _observers;
        
        MyEventObservable()
        {
            // Initialize the dictionary with all the events
        }
        
        public void RegisterObserver(kEvents event, IObserver observer)
        {
            _observers[event].Add(observer);
        }
    }
    
    interface class IObserver
    {    
        void Notify(kEvents anEvent);
    }
    
    public MyEventObserver: IObserver
    {
        // Constructors and all
        // ...
        
        // Override the IObserver
        public void Notify(kEvents anEvent)
        {
            switch(anEvent)
            {
                // switch through all the events and handle the ones that you need
            }
        }
    }
    
    MyEventObserver observer = new MyEventObserver();
    MyEventObservable observable = new MyEventObservable();
    observable.RegisterObserver(kEvents.Start, observer);
