    namespace BindingCppDllExample
    {
        public class BindingDllClass
        {
            [DllImport("MathFuncsDll.dll")]
            public static extern double Add(double a, double b);
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                double a = 2.3;
                double b = 3.8;
                double c = BindingDllClass.Add(a, b);
    
                Console.WriteLine(string.Format("{0} + {1} = {2}", a, b, c));
            }
        }
    }
