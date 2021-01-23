    public class ExtednedObservableCollection<T> : ObservableCollection<T> {
        public ExtednedObservableCollection()
            : base() {
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
        }
        private void OnCollectionChanged(object o, NotifyCollectionChangedEventArgs e) {
            if (e.NewItems != null) {
                foreach (Object item in e.NewItems) {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null) {
                foreach (Object item in e.OldItems) {
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(a);
        }
    }
