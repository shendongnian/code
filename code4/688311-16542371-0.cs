    class MyClass
    {
        Object value;
        public MyClass(int value)
        {
            this.value = value;
        }
        public MyClass(long value)
        {
            this.value = value;
        }
        public MyClass(string value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
