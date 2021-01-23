    public class MyWrapper
    {
        public MyWrapper(InitParameters p)
        {
            lock (lockRoot)
            {
                if (!initialized)
                {
                    UnManagedStaticClass.Initialize(p);
                    initialized = true;
                }
            }
        }
        static bool initialized = false;
        static object lockRoot = new Object();
        public void Method1()
        {
            lock (lockRoot)
            {
                UnManagedStaticClass.Settings = ...;
                UnManagedStaticClass.Method1();
            }
        }
    }
