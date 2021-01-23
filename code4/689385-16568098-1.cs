    public class ExpandoTypeDescriptor : ICustomTypeDescriptor
    {
        private readonly ExpandoObject _expando;
        public ExpandoTypeDescriptor(ExpandoObject expando)
        {
            _expando = expando;
        }
        // Just use the default behavior from TypeDescriptor for most of these
        // This might need some tweaking to work correctly for ExpandoObjects though...
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _expando;
        }
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }
        // This is where the GetProperties() calls are
        // Ignore the Attribute for now, if it's needed support will have to be implemented
        // Should be enough for simple usage...
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            // This just casts the ExpandoObject to an IDictionary<string, object> to get the keys
            return new PropertyDescriptorCollection(
                ((IDictionary<string, object>)_expando).Keys
                .Select(x => new ExpandoPropertyDescriptor(((IDictionary<string, object>)_expando), x))
                .ToArray());
        }
        // A nested PropertyDescriptor class that can get and set properties of the
        // ExpandoObject dynamically at run time
        private class ExpandoPropertyDescriptor : PropertyDescriptor
        {
            private readonly IDictionary<string, object> _expando;
            private readonly string _name;
            public ExpandoPropertyDescriptor(IDictionary<string, object> expando, string name)
                : base(name, null)
            {
                _expando = expando;
                _name = name;
            }
            public override Type PropertyType
            {
                get { return _expando[_name].GetType(); }
            }
            public override void SetValue(object component, object value)
            {
                _expando[_name] = value;
            }
            public override object GetValue(object component)
            {
                return _expando[_name];
            }
            public override bool IsReadOnly
            {
                get
                {
                    // You might be able to implement some better logic here
                    return false;
                }
            }
            public override Type ComponentType
            {
                get { return null; }
            }
            public override bool CanResetValue(object component)
            {
                return false;
            }
            public override void ResetValue(object component)
            {
            }
            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
            public override string Category
            {
                get { return string.Empty; }
            }
            public override string Description
            {
                get { return string.Empty; }
            }
        }
    }
