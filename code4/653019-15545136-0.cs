    class MyClass
    {
        private SomeType innerObj = new SomeType();
        public Bar GetFoo()
        {
            return innerObj.GetFoo();
        }
    }
