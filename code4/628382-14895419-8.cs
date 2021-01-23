    public class MyWrapper
    {
        public MyWrapper(InitParameters initParameters, Settings settings)
        {
            this.initParameters = initParameters;
            this.settings = settings;
        }
        private InitParameters initParameters;
        private Settings settings;
        static MyWrapper currentOwnerInstance;
        static object lockRoot = new Object();
        private void InitializeIfNecessary()
        {
            if (currentOwnerInstance != this)
            {
                currentOwnerInstance = this;
                UnManagedStaticClass.Initialize(initParameters);
                UnManagedStaticClass.Settings = settings;
            }
        }
        public void Method1()
        {
            lock (lockRoot)
            {
                InitializeIfNecessary();
                UnManagedStaticClass.Method1();
            }
        }
    }
