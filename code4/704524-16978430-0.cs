    class MyClass
    {
        public void UnitTestOne() { /* impl */ }
        public void UnitTestTwo() { /* impl */ }
        public void UnitTestThree() 
        {
            var actions = new Action[] { UnitTestOne, UnitTestTwo };
            var names = actions.Select(x => x.Method.Name);
        } 
    }
