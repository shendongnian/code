    public class MyClass : ICloneable
    {
        public MyClass Clone()
        {
            MyClass clone = new MyClass();
            // Copy property values to clone-instance.
            return clone;
        }
    }
