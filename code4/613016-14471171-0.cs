    public class MultiThreadedObservableCollection<T> : ObservableCollection<T> {
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        public MultiThreadedObservableCollection() { }
        public MultiThreadedObservableCollection(IEnumerable<T> source) : base(source) { }
        public MultiThreadedObservableCollection(List<T> source) : base(source) { }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
            var handle = CollectionChanged;
            if (CollectionChanged == null)
                return;
            foreach (NotifyCollectionChangedEventHandler handler in handle.GetInvocationList()) {
                var dispatcherObj = handler.Target as DispatcherObject;
                if (dispatcherObj != null) {
                    var dispatcher = dispatcherObj.Dispatcher;
                    if (dispatcher != null && !dispatcher.CheckAccess()) {
                        dispatcher.BeginInvoke(
                            (Action)(() => handler.Invoke(
                                this,
                                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
                            ), DispatcherPriority.DataBind);
                        continue;
                    }
                }
                handler.Invoke(this, e);
            }
        }
    }
