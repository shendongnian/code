    class ClassWStaticCon
    {
        public static int SomeField;
        static ClassWStaticCon()
        {
            Console.WriteLine("Hello world!");
        }
    }
    ...
    static void Main(string[] args)
    {
        ClassWStaticCon.SomeField = 0;
        Console.WriteLine("Hello main.");
    }
