    static void Main()
    {
        bool converted = false;
        short sNum = 0;
        while (!converted)
        {
            try
            {
                sNum = Convert.ToInt16(Console.ReadLine());
                converted = true;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("output is {0}", sNum);
        Console.ReadLine();
    }
