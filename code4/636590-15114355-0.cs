     public class A {  }
    public class B : A { }
    public class C : A { }
    public static class Helper
    {
        public static Action<A> DoSomething;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();
            var c = new C();
            Helper.DoSomething = new Action<A>(DoSomething1);
            Helper.DoSomething = (Action<A>)new Action<B>(DoSomething2);
            Helper.DoSomething = (Action<A>)new Action<C>(DoSomething3);                       
        }
        public static void DoSomething1(A a) { }
        public static void DoSomething2(B a) { }
        public static void DoSomething3(C a) { }
    }
