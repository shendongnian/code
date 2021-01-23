    public class FirstObject<T, U> : IItem
    {
        public FirstObject(U value)
        {
            SomeProperty = value;
        }
    
        public U SomeProperty { get; private set; }
    
        object IItem.SomeProperty
        {
            get { return SomeProperty; }
        }
    }
