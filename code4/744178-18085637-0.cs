    struct MyClass
    {
      private short a; //Also consider ushort, if you need it
      //...
      public int A
      {
        get { return a; //Automatic promotion }
        private set
        {
          a = (short) value;
          System.Diagnostics.Debug.Assert(a == value, "Integer overflow");
        }
      }
      //...
    }
