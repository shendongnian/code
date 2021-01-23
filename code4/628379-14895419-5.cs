    public class MyWrapper
    {
        public MyWrapper()
        {
            // Do any necessary instance initialization here
        }
        static MyWrapper()
        {
            UnManagedStaticClass.Initialize();
            UnManagedStaticClass.Settings = ...;
        }
        public void Method1()
        {
            UnManagedStaticClass.Method1();
        }
    }
