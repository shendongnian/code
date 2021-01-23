    public class EntityBase : DynamicObject, INotifyPropertyChanged
    {
        public Dictionary<string, object> DynamicProperties { get; set; }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (!HasProperty(propertyName))
            {
                return;
            }
            
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public bool HasProperty(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] != null)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Ctor
        public EntityBase()
        {
            this.DynamicProperties = new Dictionary<string, object>();
        }
        #endregion
        #region DynamicObject Overrides
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();
            return this.DynamicProperties.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.DynamicProperties[binder.Name.ToLower()] = value;
            OnPropertyChanged(binder.Name);
            return true;
        }
        
        #endregion
    }
