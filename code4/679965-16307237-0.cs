    using System;
    
    class Program
    {
        static bool M(out int x)
        {
            x = 123;
            return true;
        }
    
        static int N(dynamic d)
        {
            int y = 3;
            if (d || M(out y))
                y = 10;
            return y;
        }
    
        static void Main(string[] args)
        {
            var result = N(new EvilBool());
            // Prints 3!
            Console.WriteLine(result);
        }
    }
    
    class EvilBool
    {
        private bool value;
    
        public static bool operator true(EvilBool b)
        {
            // Return true the first time this is called
            // and false the second time
            b.value = !b.value;
            return b.value;
        }
    
        public static bool operator false(EvilBool b)
        {
            throw new NotImplementedException();
        }
    }
