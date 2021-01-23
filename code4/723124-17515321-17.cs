    class OuterClass
    {
        public readonly string Value;
        private OuterClass(): this("Default Value")
        {
        }
        public OuterClass(string value)
        {
            Value = value;
        }
        public OuterClass GetInnerClass()
        {
            return new InnerClass();
        }
        private class InnerClass: OuterClass
        {
        }
    }
    
