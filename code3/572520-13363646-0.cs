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
            // the next line was changed.
            public override void Method()
            {
                Console.WriteLine("Hello from the derived.");
                // note that if you want to call the original implementation, you do it like this:
                base.Method();
            }
        }
    
        static void Main(string[] args)
        {
            Base x = new Derived();
            x.Method();
        }
    }
