    class C
    {
      private class DisplayClass
      {
        public int x;
        public int AnonymousMethod(int y)
        { 
          return this.x + y;
        }
      }
      void M()
      {
        C.DisplayClass d = new C.DisplayClass();
        d.x = 1;
        Func<int, int> f = d.AnonymousMethod;
      }
    }
