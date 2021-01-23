    public class ObservableCollectionExtender<T> : ObservableCollection<T>
    {
        /// <summary>
        /// Source: New Things I Learned
        /// Title: Have worker thread update ObservableCollection that is bound to a ListCollectionView
        /// http://geekswithblogs.net/NewThingsILearned/archive/2008/01/16/have-worker-thread-update-observablecollection-that-is-bound-to-a.aspx
        /// Note: Improved for clarity and the following of proper coding standards.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Use BlockReentrancy
            using (BlockReentrancy())
            {
                var eventHandler = CollectionChanged;
                // Only proceed if handler exists.
                if (eventHandler != null)
                {
                    Delegate[] delegates = eventHandler.GetInvocationList();
                    // Walk thru invocation list
                    foreach (NotifyCollectionChangedEventHandler handler in delegates)
                    {
                        var currentDispatcher = handler.Target as DispatcherObject;
                        // If the subscriber is a DispatcherObject and different thread
                        if ((currentDispatcher != null) &&
                            (currentDispatcher.CheckAccess() == false))
                        {
                            // Invoke handler in the target dispatcher's thread
                            currentDispatcher.Dispatcher.Invoke(
                                DispatcherPriority.DataBind, handler, this, e);
                        }
                        else
                        {
                            handler(this, e);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Overridden NotifyCollectionChangedEventHandler event.
        /// </summary>
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
    }
