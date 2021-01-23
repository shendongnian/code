        public class ObservableList<T> : ObservableCollection<T>
        {
            public ObservableList() : base()
            {
                CollectionChanged += new NotifyCollectionChangedEventHandler(nObservableCollection_CollectionChanged);
            }
            public event PropertyChangedEventHandler OnPropertyChanged;
            void nObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (OnPropertyChanged != null)
                    OnPropertyChanged(this, null); // Call method to let it change the tabpages
            }
        }
