    public class Test0
    {
        protected int bar;
        public void Unexpected() { Console.WriteLine("3. {0}", bar); }
    }
    public partial class Test1
    {
        private int foo;
        public void Foo() { Console.WriteLine("1. {0}", foo); bar = 1; }
    }
    public partial class Test1 : Test0
    {
        public void Bar() { Console.WriteLine("2. {0}", foo); foo = 1; }
    }
    class Driver
    {
        public static void Main()
        {
            var t1 = new Test1();
            t1.Bar();
            t1.Foo();
            t1.Unexpected();
            Console.ReadLine();
        }
    } 
