    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public class DataRecord : INotifyPropertyChanged, ICustomTypeDescriptor
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            internal ITypedList container;
    
            private readonly IDictionary<string, object> values = new SortedList<string, object>();
    
            public object this[string propertyName]
            {
                get
                {
                    object value;
                    this.values.TryGetValue(propertyName, out value);
                    return value;
                }
                set
                {
                    if (!object.Equals(this[propertyName], value))
                    {
                        this.values[propertyName] = value;
                        this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
                    }
                }
            }
    
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                    handler(this, e);
            }
    
            PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
            {
                return this.container.GetItemProperties(null);
            }
    
            #region Not implemented ICustomTypeDescriptor Members
    
            AttributeCollection ICustomTypeDescriptor.GetAttributes()
            {
                throw new NotImplementedException();
            }
    
            string ICustomTypeDescriptor.GetClassName()
            {
                throw new NotImplementedException();
            }
    
            string ICustomTypeDescriptor.GetComponentName()
            {
                throw new NotImplementedException();
            }
    
            TypeConverter ICustomTypeDescriptor.GetConverter()
            {
                throw new NotImplementedException();
            }
    
            EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
            {
                throw new NotImplementedException();
            }
    
            PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
            {
                throw new NotImplementedException();
            }
    
            object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
            {
                throw new NotImplementedException();
            }
    
            EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
            {
                throw new NotImplementedException();
            }
    
            EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
            {
                throw new NotImplementedException();
            }
    
            PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
            {
                throw new NotImplementedException();
            }
    
            object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    }
