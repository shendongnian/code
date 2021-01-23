    public class DynamicNpcProxy : DynamicObject, INotifyPropertyChanged
    {
        public DynamicNpcProxy(object proxiedObject)
        {
            ProxiedObject = proxiedObject;
        }
        //...
        public object ProxiedObject { get; set; }
        
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetMember(binder.Name, value);
            return true;
        }
        protected virtual void SetMember(string propertyName, object value)
        {
            GetPropertyInfo(propertyName).SetValue(ProxiedObject, value, null);
            if (PropertyChanged != null) 
                PropertyChanged(ProxiedObject, new PropertyChangedEventArgs(propertyName));
        }
        protected PropertyInfo GetPropertyInfo(string propertyName)
        {
            return ProxiedObject.GetType().GetProperty(propertyName);
        }
        // override bool TryGetMember(...)
    }
