    static void Main(string[] args)
    {
        Console.WriteLine("please imput number 1 ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("please imput number 2 ");
        int b = Convert.ToInt32(Console.ReadLine());
        if (a > b)
        {
            int temp1 = a;
            int temp2 = b;
            b = temp1;
            a = temp2;
        }
    }
