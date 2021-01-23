        static void Main()
        {
            int N;
            
            do
            {
                Console.Write("Please enter N (N >= 20 || N <= 0): ");
            }
            while (!int.TryParse(Console.ReadLine(), out N) || N >= 20 || N <= 0);
            for (int row = 1; row <= N; row++)
            {
                for (int col = row; col <= row + N - 1; )
                {
                    Console.Write(col + " ");
                    col++;
                }
                Console.WriteLine();
            } 
            Console.Read();
        }
    Please enter N (N >= 20 || N <= 0): 5
    1 2 3 4 5 
    2 3 4 5 6 
    3 4 5 6 7 
    4 5 6 7 8 
    5 6 7 8 9 
