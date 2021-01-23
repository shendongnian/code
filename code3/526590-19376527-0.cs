    public class ObservableDispatcherCollection<T> : ObservableCollection<T> where T : class
        {
            private Dispatcher _dispatcher;
    
            public ObservableDispatcherCollection(Dispatcher dispatcher)
            {
                _dispatcher = dispatcher; 
            }
     
            public ObservableDispatcherCollection(Control parent)
            {
                _dispatcher = parent.Dispatcher;
            }
    
            protected override void     OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                _dispatcher.Invoke(new Action(() =>
                {
                    base.OnCollectionChanged(e);
                }));
            }
    
            protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
            {
                _dispatcher.Invoke(new Action(() =>
                {
                    base.OnPropertyChanged(e);
                }));
            }
    }
