    int serial = 1, serial2 = 1, num, max, max2, i = 2,n;
    Console.WriteLine("Enter number of numbers");
    n = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter number");
    num = int.Parse(Console.ReadLine());
    /*case 1 */
    max = num;
    max2 = num;
    for (; i <= n; i++)
    {
        Console.WriteLine("enter num");
        num = int.Parse(Console.ReadLine());
         /* case 3 */
        if (num > max)
        {
            max2 = max;
            max = num;
            serial2 = serial;
            serial = i;
        }
          /* case 2 */
        else if (num > max2)
        {
            max2 = num;
            serial2 = i;
        }
    }
