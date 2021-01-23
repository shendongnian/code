    private void MethodStarter()
    {
        Task myFirstTask = Task.Factory.StartNew(() => Method1(5));
        Task mySecondTask = Task.Factory.StartNew(() => Method2("Hello"));
    }
    private void Method1(int someNumber)
    {
         // your code
    }
    private void Method2(string someString)
    {
         // your code
    }
