    public static class Cons 
    {
      //initialise to default as well - only web apps need change it
      private static IConsProvider _provider = new DefaultConsProvider();
      public static IConsProvider Provider 
      {
        get { return _provider; }
        set { _provider = value; /* should check for null here and throw */ }
      }
      //if you really want you can then wrap the properties
      public static string UserName 
      {
        get {
          return _provider.UserName;
        }
        set {
          _provider.UserName = value;
        }
      }
    }
