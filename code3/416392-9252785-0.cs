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
    
        public TestClass ReturnValue(position p)
        {
            lock (_syncRoot)
            {
                // Warning there's something wrong here:
                // The List<T> indexer expects an integer, so
                // cl[p] won't work. You might consider rethinking  
                // what you are trying to achieve here
                ...
 
                //return cl[p];
            }
        }
    }
