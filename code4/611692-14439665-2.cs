    public class Test : ITest
    {
        [Dependency("MyFileLogger")]
        public ILogger Logger
        {
           get { return iLogger; }
           set { iLogger = value; }
        }
    }
