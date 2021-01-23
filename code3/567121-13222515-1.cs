    int n = Convert.ToInt32(Console.ReadLine());
    int factorial = 1;
    for (int i = 1; i <= n; i++)
    {
      factorial *= i;
      Console.WriteLine("{0:x}", factorial);
    }
    Console.WriteLine(factorial);
