    public SomeConstructor() 
      : base(Configuration.MyString) {
    }
    public static Configuration {
      public static string MyString {
        get { /* some logic to determine the appropriate value */ } 
     }
    }
