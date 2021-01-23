    public interface ICommon {
      int A { get; }
    }
    public class File1 : ICommon {
      public int A { get { return 42; } }
    }
    public class File2 : ICommon {
      private int _value = 1;
      public int A { get { return _value; } }
    }
