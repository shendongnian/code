    public class PropertyWrapper<T>
    {
        readonly PropertyInfo property;
        readonly object obj;
        public PropertyWrapper(object obj, string propertyName)
        {
            property = obj.GetType().GetProperty(propertyName);
            this.obj = obj;
        }
        public T Value
        {
            get
            {
                return (T)property.GetValue(obj);
            }
            set
            {
                property.SetValue(obj, value);
            }
        }
    }
