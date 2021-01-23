     int[][] a = new int[2][];//its mean num of row is 2 which fixed
            int choice;//thats i left on user choice that how many number of column in each row he wanna to declare
            for (int row = 0; row < a.Length; row++)
            {
                Console.WriteLine("pls enter number of colo in row {0}", row);
                choice = int.Parse(Console.ReadLine());
                a[row] = new int[choice];
                for (int col = 0; col < a[row].Length; col++)
                {
                    a[row][col] = int.Parse(Console.ReadLine());
                }
            }
            //loop for out put the values of jagged array
            for (int row = 0; row < a.Length; row++)
            {
                for (int col = 0; col < a[row].Length; col++)
                    Console.Write(a[row][col]+"\t");
                Console.WriteLine("");
            }
