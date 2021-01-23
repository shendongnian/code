    public SomePubliclyVisibleClass
    {
      private static _strVal = ComputedStrVal();//we could have a public field, but 
                                                //since there are some things that
                                                //we can do with a property that we
                                                //can't with a field and it's a breaking
                                                //change to change from one to the other
                                                //we'll have a private field and
                                                //expose it through a public property
      public static StrVal
      {
        get { return _strVal; }
      }
      private static string ComputedStrVal()
      {
        //code to calculate and return the value
        //goes here
      }
    }
