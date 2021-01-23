    [MyAttribute(Name = "Test123"]
    public MyClass
    {
        public string Name 
        {
           get { return ((MyAttribute)(GetType().GetCustomAttributes(typeof(MyAttribute), true).First())).Name; }
        }
    }
