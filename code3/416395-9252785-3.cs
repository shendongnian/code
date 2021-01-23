    public class TestService
    {
        private static SynchronizedCollection<TestClass> cl;
    
        static TestService()
        {
            cl = new SynchronizedCollection<TestClass>();
            TestClass tc = new TestClass(5);
            cl.Add(tc);
        }
    
        public void Diminish(int x)
        {
            cl[0].Value -= x;
        }
    
        public TestClass ReturnValue(int p)
        {
            return cl[p];
        }
    }
