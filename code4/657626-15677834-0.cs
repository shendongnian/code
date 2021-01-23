    class MyClass
    {
        private static readonly MyClass Default = new MyClass();
        private static readonly char[] InvalidChars = new []{'\\', '/'};
        public MyClass()
        {
            if (InvalidChars == null)
            {
             //how can this block be accessable? 
            }
        } 
    }
