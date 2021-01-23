    //NOTE: this is just a sample, not a suggestion to do it in such way
    public interface I
    {
        void F();
        void G();
    }
    
    public static class A
    {
        public static void F() { System.Console.WriteLine("A: doing F()"); }
        public static void G() { System.Console.WriteLine("A: doing G()"); }
    }
    
    public static class B
    {
        public static void F() { System.Console.WriteLine("B: doing F()"); }
        public static void G() { System.Console.WriteLine("B: doing G()"); }
    }
    
    public class C : I
    {
        // delegation 
        Action iF = A.F;
        Action iG = A.G;
    
        public void F() { iF(); }
        public void G() { iG(); }
    
        // normal attributes
        public void ToA() { iF = A.F; iG = A.G; }
        public void ToB() { iF = B.F; iG = B.G; }
    }
    
    public class Program
    {
        public static void Main()
        {
            C c = new C();
            c.F();     // output: A: doing F()
            c.G();     // output: A: doing G()
            c.ToB();
            c.F();     // output: B: doing F()
            c.G();     // output: B: doing G()
        }
    }
