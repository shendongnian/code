    class Stuff
    {
      private String _SomeInfo;
      public String SomeInfo 
      { 
        get { return _SomeInfo ?? String.Empty; }
        set { _SomeInfo = value; }
      }
    }
