    class Program
    {
        static void Main()
        { 
            var standard = new StandardClass();
            var special = new SpecialClass();
            new HandleTypes(standard.GetType());
            new HandleTypes(special.GetType());
            Console.Read();
        }
    }
