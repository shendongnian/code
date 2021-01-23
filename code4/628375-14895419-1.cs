    public class MyWrapper
    {
        public MyWrapper()
        {
            // Do any necessary instance initialization here
        }
        static Test()
        {
            UnManagedStaticClass.Initialize();
        }
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
