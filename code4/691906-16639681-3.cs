    public abstract class A {
      private A() { }
    
      public abstract void DoSomething();
    
      private class OneImpl : A { 
        public override void DoSomething() { Console.WriteLine("One"); }
      }
    
      private class TwoImpl : A { 
        public override void DoSomething() { Console.WriteLine("Two"); }
      }
    
      public static readonly A One = new OneImpl();
      public static readonly A Two = new TwoImpl();
    }
