    // DLL1
    class ClassInDLL1 : IClassInDLL1
    {
    }
    // DLL2
    class ClassInDLL2
    {
        public IClassInDLL1 GetClassInDLL1()
        {
            return new ClassInDLL1();
        }
    }
    // DLL3
    class ClassInDLL3
    {
        public void DoSomething()
        {
            var dll2 = new ClassInDLL2();
            var dll1 = dll2.GetClassInDLL1(); // dll1 variable is of type IClassInDLL1
            // do stuff with dll1
        }
    }
    // interface DLL
    interface IClassInDLL1
    {
    }
