    int m, n, c, d;
    int[,] first = new int[10, 10];
    int[,] second = new int[10, 10];
    int[,] sum = new int[10, 10];
 
    Console.WriteLine("Enter the number of rows and columns of matrix");
    m = Convert.ToInt16(Console.ReadLine());
    n = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine("\nEnter the elements of first matrix\n");
 
    for (c = 0; c < m; c++)
        for (d = 0; d < n; d++)
        {
            Console.WriteLine("Enter Element [" + c + " , " + d + "]");
            first[c, d] = Convert.ToInt16(Console.ReadLine());
        }
 
    Console.WriteLine("Enter the elements of second matrix");
    for (c = 0; c < m; c++)
        for (d = 0; d < n; d++)
        {
            Console.WriteLine("Enter Element [" + c + " , " + d + "]");
            second[c, d] = Convert.ToInt16(Console.ReadLine());
        }
 
    for (c = 0; c < m; c++)
        for (d = 0; d < n; d++)
            sum[c, d] = first[c, d] + second[c, d];
 
    Console.WriteLine("Sum of entered matrices:-");
    for (c = 0; c < m; c++)
    {
        for (d = 0; d < n; d++)
            Console.Write(" " + sum[c, d]);
        Console.WriteLine();
    }
    Console.ReadKey();
