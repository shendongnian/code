    public class A {
      private AccessB linkToB;
      void SomeMethodInClassA() {
        linkToB.X = 1;
      }
    }
    public interface AccessB {
      int X { get; set; }
    }
    public class B : AccessB {
      private int x;
      int AccessB.X { get { return x; } set { x = value; } }
    };
