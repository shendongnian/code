    public class ObservableCollection2<T> : ObservableCollection<T>
    {
        public ObservableCollection2()
        {
            this.CollectionChanged += ObservableCollection2_CollectionChanged;
        }
        void ObservableCollection2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                foreach (object o in e.OldItems)
                    remove(o);
            if (e.NewItems != null)
                foreach (object o in e.NewItems)
                    add(o);
        }
        void add(object o)
        {
            INotifyPropertyChanged ipc = o as INotifyPropertyChanged;
            if(ipc!=null)
                ipc.PropertyChanged += Ipc_PropertyChanged;
        }
        void remove(object o)
        {
            INotifyPropertyChanged ipc = o as INotifyPropertyChanged;
            if (ipc != null)
                ipc.PropertyChanged -= Ipc_PropertyChanged;
        }
        void Ipc_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs f;
            f = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, sender);
            base.OnCollectionChanged(f);
            f = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, sender);
            base.OnCollectionChanged(f);
        }
    }
