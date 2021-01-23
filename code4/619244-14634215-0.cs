    using System;
    
    public class Test
    {
        static void Main()
        {        
            var method = typeof(Test).GetMethod("DummyMethod");
            object[] args = new object[1];
            method.Invoke(null, args);
            Console.WriteLine(args[0]); // Prints 10
        }
        
        public static void DummyMethod(out int x)
        {
            x = 10;
        }
    }
