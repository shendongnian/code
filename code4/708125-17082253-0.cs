    protected class PrioritizedDelegate : IComparable
    {
        public DelegateType d;
        public int priority;
        public PrioritizedDelegate(DelegateType d, int priority)
        {
            this.d = d;
            this.priority = priority;
        }
    }
