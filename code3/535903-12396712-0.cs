    int x = 1;
    int j = 10;
    int k = 0;
    while (j > 0)
    {
        if (k <= j)
        {
           Console.Write("* ");
        }
        if (j >= 1)
        {
            int temp = x;
            while (temp >= 0)
            {
                Console.Write(" ");
                temp--;
            }
            x = x + 1;
            Console.Write("*");
    
         }
           Console.WriteLine();
           j--;
       }
       Console.WriteLine();
       double f = Math.Round(x * 1.5);
       while (f != 0)
       {
          Console.Write("*");
          f--;
       }
