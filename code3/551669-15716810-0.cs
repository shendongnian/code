            int[,] values=new int[2,3]{{2,4,5},{4,5,2}};
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int k = 0; k < values.GetLength(1); k++) {
                    Console.Write(values[i,k]);
                }
                Console.WriteLine();
            }
            
