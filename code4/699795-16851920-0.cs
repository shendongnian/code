    class Foo
    {
      private int _property;
      public int Property 
      { 
        get { return _property; } 
        set
        {
          _property = value;
          if(inUpdate)
            propertyChanged = true;
          else
            //Update something anywhere else
            StaticBigFoo.Update();
        } }
        static bool inUpdate = false;
        static bool propertyChanged;
        public static void BeginUpdate() { inUpdate = true; propertyChanged = false; }
        public static void EndUpdate() { inUpdate = false; if(propertyChanged) StaticBigFoo.Update(); }
    }
