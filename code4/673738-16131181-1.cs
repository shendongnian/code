	partial class SomeClass
    {
        private static readonly PropertyDescriptorCollection LogProps = TypeDescriptor.GetProperties(typeof(SomeClass));
        public object this[string propertyName]
        {
            get { return LogProps[propertyName].GetValue(this); }
            set { LogProps[propertyName].SetValue(this, value); }
        }
	}
