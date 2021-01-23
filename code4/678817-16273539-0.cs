    class ViewModelBase : DynamicObject, INotifyPropertyChanged
    {
        #region Private Members
 
        private Dictionary<string, object> _dynamicProperties;
        #endregion Private Members
        #region Constructor
        public ViewModelBase(IEnumerable<string> propertyNames)
        {
            if (propertyNames == null)
            {
                throw new Exception("propertyNames is empty");
            }
            _dynamicProperties = new Dictionary<string, object>();
            propertyNames
                .ToList()
                .ForEach(propName => _dynamicProperties.Add(propName, null));
        }
        #endregion Constructor
        #region Public Methods
        public void SetPropertyValue(string propertyName, object value)
        {
            if (_dynamicProperties.ContainsKey(propertyName))
            {
                _dynamicProperties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
        }
        public object GetPropertyValue(string propertyName)
        {
            return _dynamicProperties.ContainsKey(propertyName) ? _dynamicProperties[propertyName] : null;
        }
        #endregion Public Methods
        #region DynamicObject Overriden Members
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool ret = base.TryGetMember(binder, out result);
            if (ret == false)
            {
                result = GetPropertyValue(binder.Name);
                if (result != null)
                {
                    ret = true;
                }
            }
            return ret;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bool ret = base.TrySetMember(binder, value);
            if (ret == false)
            {
                SetPropertyValue(binder.Name, value);
                ret = true;
            }
            return ret;
        }
        #endregion DynamicObject Overriden Members
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged Implementation
    }
