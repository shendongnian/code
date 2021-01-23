    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    [RefreshProperties(RefreshProperties.All)]
    public class DictionaryPropertyGridAdapter<TKey, TValue> : ICustomTypeDescriptor, INotifyPropertyChanged
    {
        #region Fields
        private readonly IDictionary<TKey, PropertyAttributes> propertyAttributeDictionary;
        private readonly IDictionary<TKey, TValue> propertyValueDictionary;
        #endregion
        #region Constructors and Destructors
        public DictionaryPropertyGridAdapter(
            IDictionary<TKey, TValue> propertyValueDictionary,
            IDictionary<TKey, PropertyAttributes> propertyAttributeDictionary = null)
        {
            this.propertyValueDictionary = propertyValueDictionary;
            this.propertyAttributeDictionary = propertyAttributeDictionary;
        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            foreach (var kvp in this.propertyValueDictionary)
            {
                properties.Add(
                    new DictionaryPropertyDescriptor(
                        kvp.Key,
                        this.propertyValueDictionary,
                        this.propertyAttributeDictionary));
            }
            PropertyDescriptor[] props = (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));
            return new PropertyDescriptorCollection(props);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public class PropertyAttributes
        {
            public string Category { get; set; }
            public string Description { get; set; }
            public string DisplayName { get; set; }
            public bool IsReadOnly { get; set; }
        }
        internal class DictionaryPropertyDescriptor : PropertyDescriptor
        {
            #region Fields
            private readonly IDictionary<TKey, PropertyAttributes> attributeDictionary;
            private readonly TKey key;
            private readonly IDictionary<TKey, TValue> valueDictionary;
            #endregion
            #region Constructors and Destructors
            internal DictionaryPropertyDescriptor(
                TKey key,
                IDictionary<TKey, TValue> valueDictionary,
                IDictionary<TKey, PropertyAttributes> attributeDictionary = null)
                : base(key.ToString(), null)
            {
                this.valueDictionary = valueDictionary;
                this.attributeDictionary = attributeDictionary;
                this.key = key;
            }
            #endregion
            public override string Category => this.attributeDictionary?[this.key].Category ?? base.Category;
            public override Type ComponentType => null;
            public override string Description => this.attributeDictionary?[this.key].Description ?? base.Description;
            public override string DisplayName => this.attributeDictionary?[this.key].DisplayName ?? base.DisplayName;
            public override bool IsReadOnly => this.attributeDictionary?[this.key].IsReadOnly ?? false;
            public override Type PropertyType => this.valueDictionary[this.key].GetType();
            public override bool CanResetValue(object component)
            {
                return false;
            }
            public override object GetValue(object component)
            {
                return this.valueDictionary[this.key];
            }
            public override void ResetValue(object component)
            {
            }
            public override void SetValue(object component, object value)
            {
                this.valueDictionary[this.key] = (TValue)value;
            }
            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
