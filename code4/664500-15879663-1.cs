    public class LockTest
    {
        private object obj1 = new object();
        private object obj2 = new object();
     
        public void Method1()
        {
            lock(obj1)
            {
                ...
            }
        }
     
        public void Method2()
        {
            lock(obj2)
            {
                ...
            }
        }
     
        public void Method3()
        {
            lock(obj1)
            {
                ...
            }
        }
    }
