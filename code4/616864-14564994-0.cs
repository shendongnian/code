    public class Parent
    {
        private int value;
        public virtual int GetValue()
        {
            return value;
        }
    }
    
    public class Child : Parent
    {
        public int GetOtherValue()
        {
            //"value" is no accessible in this scope
            return GetValue() + 1;
        }
    }
