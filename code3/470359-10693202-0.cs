     static void Main(string[] args)
        {
            int xd2 = 5;
            for (decimal xd = (decimal)xd2; xd <= 6; xd += 0.01M)
            {
                Console.WriteLine(xd);
            }
            Console.ReadLine();
        }
