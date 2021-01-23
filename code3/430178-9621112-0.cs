    class Program
    {
        static void Main(string[] args)
        {
            TestClass t = new TestClass(new Service());
            t.PerformTask();
            Console.ReadKey();
        }
    }
    public class Service : IService
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something");
        }
    }
    public class TestClass
    {
        private readonly IService service;
        private delegate void TestDelegate();
        private bool conditionIsMet = true;
        public TestClass(IService service)
        {
            this.service = service;
        }
        public void PerformTask()
        {
            while (conditionIsMet)
            {
                var testDelegate = new TestDelegate(service.DoSomething);
                testDelegate.BeginInvoke(TestCallback, null);
                Thread.Sleep(1);
            }
        }
        private void TestCallback(IAsyncResult result)
        {
            var asyncResult = (AsyncResult)result;
            var testDelegate = (TestDelegate)asyncResult.AsyncDelegate;
            testDelegate.EndInvoke(asyncResult);
            // After exiting this method the loop in PerformTask() ceases to execute.
            // Is it being blocked here somehow?
        }
    }
    public interface IService
    {
        void DoSomething();
    }
