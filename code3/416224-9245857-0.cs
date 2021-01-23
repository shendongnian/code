    class Prg
    {
        public static void Main(string[] args)
        {
            int captured = 5;
            int param = 3;
            var func = new Func<int, int>(x => x * captured);
            Console.WriteLine(func(param));
            captured = 6;
            Console.WriteLine(func(param));
           
        }
    }
