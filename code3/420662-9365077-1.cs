    public MyClass webServiceClass = IMyFactoryInterface.Create();
    public static MyClassFactory : IMyFactoryInterface
    {
        public static MyClass Create(params anyParametersRequired)
        {    
            // Do Something
        }
    }
