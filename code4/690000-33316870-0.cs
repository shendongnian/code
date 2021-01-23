    static void Main()
    {
        int numberFactorial = int.Parse(Console.ReadLine());
        int result = numberFactorial;
        for (int i = 1; i < numberFactorial; i++)
        {
            result = result * i;
            Console.WriteLine("{0}*{1}",numberFactorial,i);
        }
        Console.WriteLine(result);
    }
