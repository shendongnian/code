    public class X1 {
       private X X;
       X1() {
           X = new X();
       }
       public int A { get { return X.A; } set { X.A = value } }
       public bool DoSomething() {
          return X.DoSomething();
       }
    }
