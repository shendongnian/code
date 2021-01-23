    class PrioritizedEvent<TDelegateType> where TDelegateType : class
    {
        private readonly List<PrioritizedDelegate> delegates
            = new List<PrioritizedDelegate>();
    
        public void AddDelegate(TDelegateType callback, int priority)
        {
            delegates.Add(new PrioritizedDelegate(callback, priority));
            delegates.Sort((x,y) => x.Priority.CompareTo(y.Priority));
        }
    
        protected class PrioritizedDelegate
        {
            public TDelegateType Callback {get;private set;}
            public int Priority {get;private set;}
    
            public PrioritizedDelegate(TDelegateType callback, int priority)
            {
                Callback = callback;
                Priority = priority;
            }
        }
    }
