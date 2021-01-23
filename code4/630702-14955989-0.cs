    public class A {
      public object this[int index] { get; }
    }
    public class B : A {
      public object this[int index] {
        get { return base[index]; }
      }
    }
