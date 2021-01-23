    [MyAttribute(MyClass.MyClassName)]
    public MyClass
    {
        public const string MyClassName = "Test123";
        
        public string Name 
        {
           get { return MyClass.MyClassName; }
        }
    }
