    static void Main(string[] args)
    {
        bool A = true;
        bool B = false;
        bool C = true;
        bool D = true;
        bool result1 = (A || B) && C && D;
        Console.WriteLine("Old way: " + result1);
        bool result2 = false;
        if (A || B)
        {
            if (C)
            {
                if (D)
                {
                    result2 = true;
                }
            }
        }
        Console.WriteLine("New way: " + result2);
        Console.ReadKey();
    }
