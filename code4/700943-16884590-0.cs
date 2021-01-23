    public class MyClass {
      public MyClass(int index) {
        Index = index;
      }
      public int Index {
        get { return _index; }
        private set { _idex = value; /* Perform other actions triggered by the set */ }
      }
      private int _index;
    }
