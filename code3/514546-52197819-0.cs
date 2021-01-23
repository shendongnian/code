            Console.Write("Enter N: (N < 20) ");
            int n = Int32.Parse(Console.ReadLine());
            for (int row = 1; row <= n;row++)
            {
                Console.Write(row+" ");
                for (int col = row+1; col <= row + n - 1; )
                {
                    Console.Write(col + " ");
                    col++;
                }
                Console.WriteLine();
                
            }
            Console.ReadLine();
