    static int SumToN(int n)
    {
        if (n > 0)
            // uses the formula for the sum of numners 1..n
            return n * (n + 1) / 2;
        else
            return 0;
    }
    
    static void Main(string[] args)
    {
        int i = 0;
        int sum = 0;
        Console.Write("Enter a number: ");
        i = (Convert.ToInt32(Console.ReadLine()));
        sum = SumToN(i);
        Console.WriteLine(sum.ToString());
        Console.Read();
    }
