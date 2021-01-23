    class Program
    {
        interface IBase
        {
            void Method();
        }
    
        public class Base: IBase
        {
            public virtual void Method()
            {
                Console.WriteLine("Hello from the base.");
            }
        }
    
        public class Derived : Base
        {
            public override void Method() // The magic happens here!
            {
                Console.WriteLine("Hello from the derived.");
            }
        }
    
        static void Main(string[] args)
        {
            IBase x = new Derived();
            x.Method();
        }
    }
