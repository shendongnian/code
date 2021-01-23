    public class ExampleClass
    {
        // have property expose the "default" if not yet set
        public int Value { get; private set; }
    
        // remove default, doesn't work
        public ExampleClass(int value)
        {
            Value = value;
        }
    }
