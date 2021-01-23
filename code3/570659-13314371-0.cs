    namespace StackOverflow.Demos
    {
        class Program
        {
    
            public static void Main(string[] args)
            {
                C c = new C();
                Type myType = c.GetType();
                while(myType != null)
                {
                    Console.WriteLine(myType);
                    myType = myType.BaseType;
                }
                Console.ReadKey();
            }
        }
        public class A { public A() { } }
        public class B : A { public B() { } }
        public class C : B { public C() { } }
    }
    
