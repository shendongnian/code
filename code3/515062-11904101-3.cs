    public class MyItemPropertyDescriptor : PropertyDescriptor
    {
        private object _value;
        public MyItemPropertyDescriptor(string name, object value)
            : base(name, new[] { new TypeConverterAttribute(typeof(ExpandableObjectConverter)) })
        {
            _value = value;
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override object GetValue(object component)
        {
            return _value;
        }
        public override Type PropertyType
        {
            get { return _value == null ? typeof(object) : _value.GetType(); }
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get { return typeof(object); }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override void ResetValue(object component)
        {
        }
        public override void SetValue(object component, object value)
        {
        }
    }
