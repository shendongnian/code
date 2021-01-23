    abstract class GeneralField
    {
        // ...
        public abstract void SetValue(object value);
    }
    class Int32Field : GeneralField
    {
        // ...
        public override void SetValue(object value)
        {
            Value = (int)value;
        }
    }
