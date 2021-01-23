    class SomeClass
    {
        void someFunction()
        {
            Action<string> myAction = Whatever;
            new List<string>().ForEach(myAction);
        }
    
        public void Whatever(string what)
        {
            // ... whenever
        }
    }
