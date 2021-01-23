    static void Main()
    {
            int whichClass = 0;
            TestAbstract clTest = null;
            if (whichClass == 0)
                clTest = new ClassA();
            else if (whichClass == 1)
                 clTest = new ClassB();
            else if (whichClass == 10)
                 clTest = new ClassX();
            if(clTest != null)
                 clTest.MainFunc();
        
}
