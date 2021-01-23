    internal void PrintFizzBuzzAlternative(int num)
    {
        if (num % 5 == 0)
            Console.Write("Fizz");
        if (num % 3 == 0)
            Console.Write("Buzz");
        if (num % 5 != 0 && num % 3 != 0)
            Console.Write(num);
        Console.WriteLine();
    }
