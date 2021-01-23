    static void Main(string[] args)
        {
            Console.WriteLine("geef een leeftijd");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("geef een leeftijd");
            int b = Convert.ToInt32(Console.ReadLine());
            int einde = Sum(a, b);
            Console.WriteLine(einde);
        }
        static int Sum(int x, int y)
        {
            int result = x + y;
            return result;
