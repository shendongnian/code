    class P
    {
        static object b = 5;
        static void M(ref object a) 
        { 
            b = 2;
            Console.WriteLine(a);
        }
        static void Main()
        {
            M(ref b);
        }
    }
