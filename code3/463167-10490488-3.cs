    public static void getsales ()
    {
        string inputsales;
        double total = 0;
        double sale = 0;
        for (int salecount = 1; salecount <= 3; ++salecount)
        {
            Console.WriteLine("Enter sale: ");
            inputsales = Console.ReadLine();
            sale = Convert.ToDouble(inputsales);
            total = total + sale;
            Console.WriteLine();
        }
        calcComm(total);
    }
    public static void calcComm (double total)
    {
        double comm = 0;
        comm = total * 0.2;
        Console.WriteLine(comm);
    }
