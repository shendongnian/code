    public class Variable
    {
        public static int i = 5;
        public void test()
        {
            i = i + 5;
            Console.WriteLine(i);
        }
    }
    
    public class Exercise
    {
        static void Main()
        {
            Variable var = new Variable();
            var.test();
            Variable var1 = new Variable();
            var1.test();
            Console.ReadKey();
        }
    }
