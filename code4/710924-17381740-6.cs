    public class vm : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IEntityStateProvider _stateProvider;
        private string _property;
    
        public vm(IEntityStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
            Property = "";
            _stateProvider.Save(this);
        }
    
        public string Property
        {
            get { return _property; }
            set
            {
                if (value == _property) return;
                _property = value;
                OnPropertyChanged("Property");
                OnPropertyChanged("Item[]");
            }
        }
    
        public bool this[string propertyName]
        {
            get { return _stateProvider.HasChanges(this, propertyName); }
        }
    
        #region Implementation of IDataErrorInfo
    
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                //Your logic here
                return null;
            }
        }
    
        string IDataErrorInfo.Error
        {
            get
            {
                //Your logic here
                return null;
            }
        }
    
        #endregion
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
