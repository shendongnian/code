    public class Test : ITest
    {
        public Test([Dependency("MyFileLogger")] ILogger logger)
        {
             //// you will have an instance of MyFileLogger
        }
    }
