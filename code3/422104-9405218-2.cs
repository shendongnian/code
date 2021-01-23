    public class Foo
    {
        private static object _LOCK = new object();
        public void Method1()
        {
            lock (_LOCK)
            {
                // Use resource r
            }
        }
        public void Method2()
        {
            lock (_LOCK)
            {
                // Use resource r
            }
        }
    }
