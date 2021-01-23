        // generic delegate for genric events
    public delegate void EventsHandler<in TArgs>(TArgs args) where TArgs : EventArgs;
    // generic singleton
    public abstract class EventsBase<TEvents> where TEvents : class, new()
    {
        private static readonly object lockObject = new object();
        private static volatile TEvents instance;
        public static TEvents Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new TEvents();
                        }
                    }
                }
                return instance;
            }
        }
    }
    public class EventArgs<T> : EventArgs
    {
        public T Item { get; set; }
        public EventArgs(T item)
        {
            Item = item;
        }
    }
    public class MyEvents : EventsBase<MyEvents>
    {
        public event EventsHandler<EventArgs<IList<int>>> OnCheckedDataBase;
        public event EventsHandler<EventArgs<IList<int>>> OnProcessedData;
        public void CheckedDataBase(IList<int> handler)
        {
            if (OnCheckedDataBase != null)
            {
                OnCheckedDataBase(new EventArgs<IList<int>>(handler));
            }
        }
        public void ProcessedData(IList<int> handler)
        {
            if (OnProcessedData != null)
            {
                OnProcessedData(new EventArgs<IList<int>>(handler));
            }
        }
        
     }
    MyEvents.Instance.OnCheckedDataBase += OnCheckedDataBase; //register
    MyEvents.Instance.CheckedDataBase(this);  //fire
