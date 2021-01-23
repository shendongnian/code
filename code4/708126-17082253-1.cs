    class PrioritizedEvent<TDelegateType> where TDelegateType : class
    {
        private readonly List<PrioritizedDelegate> delegates
            = new List<PrioritizedDelegate>();
    
        public void AddDelegate(TDelegateType callback, int priority)
        {
            delegates.Add(new PrioritizedDelegate(callback, priority));
            delegates.Sort();
        }
    
        protected class PrioritizedDelegate : IComparable
        {
            public readonly TDelegateType d; /* yeuch, public fields */
            public readonly int priority;
    
            public PrioritizedDelegate(TDelegateType d, int priority)
            {
                this.d = d;
                this.priority = priority;
            }
    
            int IComparable.CompareTo(object obj) { /* ... */ }
        }
    }
