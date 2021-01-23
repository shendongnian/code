    using System;
    
    class Test
    {
        static void Main()
        {
            object[,] o = new object[,]
            {
                { "x", "y" },
                { "a", "b" }
            };
            string[,] x = Cast2D<string>(o);
            Console.WriteLine(x[1, 1]); // "b"
        }
        
        static T[,] Cast2D<T>(object[,] input)
        {
            int rows = input.GetLength(0);
            int columns = input.GetLength(1);
            T[,] ret = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    ret[i, j] = (T) input[i, j];
                }
            }
            return ret;
        }        
    }
