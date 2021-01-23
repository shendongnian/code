    class Program
    {
        static void Main(string[] args)
        {
            var baseC = new BaseClass();
            var extC = new ExtClass();
            var lazyC = new LazyClass();
            Console.WriteLine(baseC.NewMethod());
            Console.WriteLine(baseC.VirtualOverrideMethod());
            Console.WriteLine("---");
            Console.WriteLine(extC.NewMethod());
            Console.WriteLine(extC.VirtualOverrideMethod());
            Console.WriteLine("---");
            Console.WriteLine(((BaseClass) extC).NewMethod());
            Console.WriteLine(((BaseClass) extC).VirtualOverrideMethod()); // Redundant typecast
            Console.WriteLine("---");
            Console.WriteLine(lazyC.VirtualOverrideMethod());
            Console.ReadKey();
        }
        public class BaseClass
        {
            public BaseClass()
            {
                
            }
            public string NewMethod()
            {
                return "NewMethod of BaseClass";
            }
            public virtual string VirtualOverrideMethod()
            {
                return "VirtualOverrideMethod of BaseClass";
            }
        }
        class ExtClass : BaseClass
        {
            public new string NewMethod()
            {
                return "NewMethod of ExtClass";
            }
            public override string VirtualOverrideMethod()
            {
                return "VirtualOverrideMethod of ExtClass";
            }
        }
        class LazyClass : BaseClass
        {
        }
    }
