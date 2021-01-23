    class Program
        {
            static void Main(string[] args)
            {
                A inst1 = new B();
                B inst2 = new B();
    
                Console.Read();
            }
        }
    
        public abstract class A
        {
            static A()
            {
                Console.WriteLine("Hello From static ctor A");
            }
    
            public A()
            {
                Console.WriteLine("Hello From default ctor A");
            }
        }
    
        public class B : A
        {
            public B()
            {
                Console.WriteLine("Hello From B");
            }
        }
    
        /* RESULTS
         *  Hello From static ctor A
            Hello From default ctor A
            Hello From B
            Hello From default ctor A
            Hello From B
         * */
