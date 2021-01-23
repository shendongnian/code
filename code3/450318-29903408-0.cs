    public class SynchronizedNotifyPropertyChanged<T> : INotifyPropertyChanged, ICustomTypeDescriptor
        where T : INotifyPropertyChanged
    {
        private readonly T _source;
        private readonly ISynchronizeInvoke _syncObject;
        public SynchronizedNotifyPropertyChanged(T source, ISynchronizeInvoke syncObject)
        {
            _source = source;
            _syncObject = syncObject;
            _source.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            var handler = PropertyChanged;
            _syncObject.BeginInvoke(handler, new object[] { this, new PropertyChangedEventArgs(propertyName) });
        }
        public T Source { get { return _source; }}
        #region ICustomTypeDescriptor
        public AttributeCollection GetAttributes()
        {
            return new AttributeCollection(null);
        }
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(typeof(T));
        }
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(typeof (T));
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(typeof (T));
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(typeof (T));
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(typeof(T));
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(typeof (T), editorBaseType);
        }
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(typeof(T));
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(typeof (T), attributes);
        }
        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(typeof (T));
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(T), attributes);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _source;
        }
        #endregion ICustomTypeDescriptor
    }
