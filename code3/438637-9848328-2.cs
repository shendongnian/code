    public class ViewModel : INotifyPropertyChanged
    {
        #region Properties
        
        private ObservableCollection<string> _collection1;
        /// <summary>
        /// This is the first collection.
        /// </summary>
        public ObservableCollection<string> Collection1
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
        private ObservableCollection<string> _collection2;
        /// <summary>
        /// This is the second collection.
        /// </summary>
        public ObservableCollection<string> Collection2
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
            _collection1 = new ObservableCollection<string>
                {   
                    "Item1", "Item2", "Item3", "Item4", "Item5", 
                    "Item6", "Item7", "Item8", "Item9", "Item10"
                };
            // Seconf collection is empty
            _collection2 = new ObservableCollection<string>();
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
