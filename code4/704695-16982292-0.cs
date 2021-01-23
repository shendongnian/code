    public delegate string SomeDelegate(object someObject);
    
    private SomeDelegate someName1;
    private static SomeDelegate someName2;
    
    internal SomeDelegate someProperty
    {
          get { return someName1?? (someName1= someName2); }
          set { someName1= value; }
    }
