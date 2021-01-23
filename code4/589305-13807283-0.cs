    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public class MyAttributeAttribute : Attribute
    {
        public bool Enabled { get; private set; }
        
        public MyAttributeAttribute()
            :this(true)
        {
        }
        public MyAttributeAttribute(bool enabled)
        {
            Enabled = enabled;
        }
    }
