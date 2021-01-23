    [Intercept(typeof(MyLogInterceptor))]
    public class MyClass : IMyClass, ICanLog
    {
        public ILog Log { get; set; }
        public void Test()
        {
           Log.Write("Test");
        }
    }
