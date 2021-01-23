    public class ViewModel<T> : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<T> _collection1;
        /// <summary>
        /// This is the first collection.
        /// </summary>
        public ObservableCollection<T> Collection1
        {
            get { return _collection1; }
            set
            {
                if (value != _collection1)
                {
                    _collection1 = value;
                    NotifyPropertyChanged("Collection1");
                }
            }
        }
        private ObservableCollection<T> _collection2;
        /// <summary>
        /// This is the second collection.
        /// </summary>
        public ObservableCollection<T> Collection2
        {
            get { return _collection2; }
            set
            {
                if (value != _collection2)
                {
                    _collection2 = value;
                    NotifyPropertyChanged("Collection2");
                }
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ViewModel()
        {
            // Create initial collections.
            
            // Populate first collection with sample data
            _collection1 = new ObservableCollection<T>();
            // Seconf collection is empty
            _collection2 = new ObservableCollection<T>();
        }
        #endregion
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
