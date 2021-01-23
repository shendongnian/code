    class MyClass
    {
        private int _a;
        public void AnotherCaller()
        {
            SomeMethod(ref _a);
            ...
        }
    }
