    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter your number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        bool isPrime = true;
        for (int i = 2; i < num/2; i++)
        {
            if (num % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            Console.WriteLine("It is Prime");
        else
            Console.WriteLine("It is not Prime");
        Console.ReadLine();
    }
