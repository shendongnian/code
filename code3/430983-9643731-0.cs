    class Program
    {
      static void Main(string[] args)
      {
         var b = new B();
         var c = new C(b);
         var a = c.GetA();
      }
    }
    public class A
    {
      private readonly B b;
      private readonly C c;
      public abstract class AFactory
      {
         private B b;
         public AFactory(B b)
         {
            this.b = b;
         }
         protected A GetA(C c)
         {
            return new A(b, c);
         }
         abstract public A GetA();
      }
      private A(B b, C c)
      {
         this.b = b;
         this.c = c;
      }
    }
    public class B
    {
    }
    public class C
    {
      private readonly B b;
      private CAFactory afactory;
      private class CAFactory : A.AFactory
      {
         private C c;
         public CAFactory(C c) : base(c.b)
         {
            this.c = c;
         }
         public A GetA()
         {
            return GetA(c);
         }
      }
      public C(B b)
      {
         this.b = b;
         afactory = new CAFactory(this);
      }
      public A GetA()
      {
         return afactory.GetA();
      }
    }
