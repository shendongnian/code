    [DataContract]
    public abstract class DataModelBase : INotifyPropertyChanged, IDataErrorInfo {
        #region Properties
        [IgnoreDataMember]
        public object Self {
            get { return this; }
            //only here to trigger change
            set { OnPropertyChanged("Self"); }
        }
        #endregion Properties
        #region Members
        [IgnoreDataMember]
        public Dispatcher Dispatcher { get; set; }
        [DataMember]
        private Dictionary<object, string> _properties = new Dictionary<object, string>();
        #endregion Members
        #region Initialization
        public DataModelBase() {
            if(Application.Current != null) Dispatcher = Application.Current.Dispatcher;
            _properties.Clear();
            RegisterProperties();
        }
        #endregion Initialization
        #region Abstract Methods
        /// <summary>
        /// This method must be defined
        /// </summar
        protected abstract void RegisterProperties();
        #endregion Abstract Methods
        #region Behavior
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool RegisterProperty<T>(ref T property, string propertyName) {
            //causes problems in design mode
            //if (property == null) throw new Exception("DataModelBase.RegisterProperty<T> : ref T property cannot be null.");
            if (_properties.ContainsKey(property)) return false;
            _properties.Add(property, propertyName);
            return true;
        }
        protected string GetPropertyName<T>(ref T property) {
            if (_properties.ContainsKey(property))
                return _properties[property];
            return string.Empty;
        }
        protected bool SetProperty<T>(ref T property, T value) {
            //if (EqualityComparer<T>.Default.Equals(property, value)) return false;
            property = value;
            OnPropertyChanged(GetPropertyName(ref property));
            OnPropertyChanged("Self");
            return true;
        }
        [OnDeserialized]
        public void AfterSerialization(StreamingContext context) {
            if (Application.Current != null) Dispatcher = Application.Current.Dispatcher;
            //---for some reason this member is not allocated after serialization
            if (_properties == null) _properties = new Dictionary<object, string>();
            _properties.Clear();
            RegisterProperties();
        }
        #endregion Behavior
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged Members
        #region IDataErrorInfo Members
        string IDataErrorInfo.Error {
            get { throw new NotImplementedException(); }
        }
        string IDataErrorInfo.this[string propertyName] {
            get { throw new NotImplementedException(); }
        }
        #endregion IDataErrorInfo Members
    } //End class DataModelBaseclass DataModelBase
    /*I decided to add an example subclass*/
        [DataContract]
    public abstract class DatabaseTraits : DataModelBase {
        #region Properties
        private long _id = -1;
        [DataMember]
        public long Id {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private bool _isLocked = false;
        [DataMember]
        public bool IsLocked {
            get { return _isLocked; }
            set { SetProperty(ref _isLocked, value); }
        }
        private string _lockedBy = string.Empty;
        [DataMember]
        public string LockedBy {
            get { return _lockedBy; }
            set { SetProperty(ref _lockedBy, value); }
        }
        private DateTime _lockDate = new DateTime(0);
        [DataMember]
        public DateTime LockDate {
            get { return _lockDate; }
            set { SetProperty(ref _lockDate, value); }
        }
        private bool _isDeleted = false;
        [DataMember]
        public bool IsDeleted {
            get { return _isDeleted; }
            set { SetProperty(ref _isDeleted, value); }
        }
        #endregion Properties
        #region Initialization
        public DatabaseTraits() : base() {
            /*makes sure my overriden RegisterProperties() is called.*/
        }
        protected override void RegisterProperties() {
            RegisterProperty(ref _id, "Id");
            RegisterProperty(ref _isLocked, "IsLocked");
            RegisterProperty(ref _lockedBy, "LockedBy");
            RegisterProperty(ref _lockDate, "LockDate");
            RegisterProperty(ref _isDeleted, "IsDeleted");
        }
        #endregion Initialization
        #region Methods
        public void Copy(DatabaseTraits that) {
            Id = that.Id;
            IsLocked = that.IsLocked;
            LockedBy = that.LockedBy;
            LockDate = that.LockDate;
            IsDeleted = that.IsDeleted;
        }
        #endregion Methods
    }
