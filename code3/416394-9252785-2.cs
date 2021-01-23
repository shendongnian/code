    public class TestService : ITestService {
        private static List<TestClass> cl;
        private static object _syncRoot = new object();
    
        static TestService()
        {
            cl = new List<TestClass>();
            TestClass tc = new TestClass(5);
            cl.Add(tc);
        }
    
        public void Diminish(int x)
        {
             lock (_syncRoot)
             {
                 cl[0].Value -= x;
             }
        }
    
        public TestClass ReturnValue(int p)
        {
            lock (_syncRoot)
            {
                return cl[p];
            }
        }
    }
