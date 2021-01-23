    using System;
    
    class Program
    {
        static void Main(string[] args)        
        {
            string[,] values = {
                {"x", "y", "z"},
                {"a", "b", "c"},
                {"0", "1", "2"}
            };
            
            values = RemoveRow(values, 1);
            
            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int column = 0; column < values.GetLength(1); column++)
                {
                    Console.Write(values[row, column]);
                }
                Console.WriteLine();
            }
        }
        
        private static string[,] RemoveRow(string[,] array, int row)
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);
            string[,] ret = new string[rowCount - 1, columnCount];
            
            Array.Copy(array, 0, ret, 0, row * columnCount);
            Array.Copy(array, (row + 1) * columnCount,
                       ret, row * columnCount, (rowCount - row - 1) * columnCount);
            return ret;
        }
    }
