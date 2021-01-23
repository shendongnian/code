    Console.Write("Enter your number: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("The prime numbers are:");
    for (int i = 1; i <= n; i++)
        if (isPrime(i))
            Console.WriteLine(i);
    Console.ReadLine();
