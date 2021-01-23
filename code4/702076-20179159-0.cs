       for (int r = 0; r < table.GetLength(0); r++)
        {
            for (int k = 0; k < table.GetLength(0); k++)
            {
                Console.Write((table[r, k] + " " ));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
        Console.ReadLine();
