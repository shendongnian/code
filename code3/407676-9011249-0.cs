    [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
    public MyClass : IMyInterface
    {
        public MyClass() { } // you can have a public ctor, no need to implement the singleton pattern 
    }
