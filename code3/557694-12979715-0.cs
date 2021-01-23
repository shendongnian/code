    public class ThreadSafeObservableCollection<T> : ObservableCollection<T>
    {
        private SynchronizationContext SynchronizationContext;
        public ThreadSafeObservableCollection()
        {
            SynchronizationContext = SynchronizationContext.Current;
            // current synchronization context will be null if we're not in UI Thread
            if (SynchronizationContext == null)
                throw new InvalidOperationException("This collection must be instantiated from UI Thread, if not, you have to pass SynchronizationContext to con                                structor.");
        }
        public ThreadSafeObservableCollection(SynchronizationContext synchronizationContext)
        {
            if (synchronizationContext == null)
                throw new ArgumentNullException("synchronizationContext");
            this.SynchronizationContext = synchronizationContext;
        }
        protected override void ClearItems()
        {
            this.SynchronizationContext.Send(new SendOrPostCallback((param) => base.ClearItems()), null);
        }
        protected override void InsertItem(int index, T item)
        {
            this.SynchronizationContext.Send(new SendOrPostCallback((param) => base.InsertItem(index, item)), null);
        }
        protected override void RemoveItem(int index)
        {
            this.SynchronizationContext.Send(new SendOrPostCallback((param) => base.RemoveItem(index)), null);
        }
        protected override void SetItem(int index, T item)
        {
            this.SynchronizationContext.Send(new SendOrPostCallback((param) => base.SetItem(index, item)), null);
        }
        protected override void MoveItem(int oldIndex, int newIndex)
        {
            this.SynchronizationContext.Send(new SendOrPostCallback((param) => base.MoveItem(oldIndex, newIndex)), null);
        }
    }
