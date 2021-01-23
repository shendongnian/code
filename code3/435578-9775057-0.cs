    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            List<int[]> list = new List<int[]>
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
            };
            
            int[,] array = CreateRectangularArray(list);
            foreach (int x in array)
            {
                Console.WriteLine(x); // 1, 2, 3, 4, 5, 6
            }
            Console.WriteLine(array[1, 2]); // 6
        }
        
        static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
        {
            // TODO: Validation and special-casing for arrays.Count == 0
            int minorLength = arrays[0].Length;
            T[,] ret = new T[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int j = 0; j < minorLength; j++)
                {
                    ret[i, j] = array[j];
                }
            }
            return ret;
        }
                       
    }
