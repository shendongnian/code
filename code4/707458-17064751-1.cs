    class Stuff
    {
      private String _SomeInfo = string.Empty;
      public String SomeInfo 
      { 
        get { return _SomeInfo; }
        set 
        { 
          if (value != null)
          {
            _SomeInfo = value; 
          }
        }
      }
    }
