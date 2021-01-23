    public class MyObject : ICustomTypeDescriptor
    {
        [DisplayName("ZZZZ")]
        public int AProperty
        {
            get;
            set;
        }
        [DisplayName("BBBB")]
        public int BProperty
        {
            get;
            set;
        }
        public PropertyDescriptorCollection GetProperties()
        {
            // Creates a new collection and assign it the properties for button1.
            var properties = TypeDescriptor.GetProperties(this)
                              .OfType<PropertyDescriptor>();
            var result = properties.OrderBy(x => x.DisplayName);
            return new PropertyDescriptorCollection(result.ToArray());
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = TypeDescriptor.GetProperties(this, attributes, true)
                              .OfType<PropertyDescriptor>();
            var result = properties.OrderBy(x => x.DisplayName);
            return new PropertyDescriptorCollection(result.ToArray());
        }
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
            return TypeDescriptor.GetDefaultProperty(this, true);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
