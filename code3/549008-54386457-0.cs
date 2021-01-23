    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
    public class ConstantAttribute: Attribute
    {
        public ConstantAttribute(string key, object value)
        {
            // ...
        }
    }
