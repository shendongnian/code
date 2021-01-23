    public abstract class XBase<T>
    {
        ObservableCollection<T> _resultCollection;
        public ObservableCollection<T> ResultCollection
        {
            get
            {
                if (_resultCollection == null)
                    _resultCollection = new ObservableCollection<T>();
                return _resultCollection;
            }
            set
            {
                _resultCollection = value;
            }
        }
    }
