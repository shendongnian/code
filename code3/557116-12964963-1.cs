    public class XProxy {
       private X X;
       XProxy() {
           X = new X();
       }
       public int A { get { return X.A; } set { X.A = value } }
       public bool DoSomething() {
          return X.DoSomething();
       }
    }
