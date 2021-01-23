    using System;
    class Program
    {
        static void Main()
        {
            mapArray = new int[,]
            {
                {0, 0, 0, 0},
                {2, 0, 0, 2},
                {0, 0, 0, 0},
                {1, 1, 1, 1}
            };
    
            // Get upper bounds for the mapArray.
            int bound0 = mapArray.GetUpperBound(0);
            int bound1 = mapArray.GetUpperBound(1);
    
            // Use for-loops to iterate over the mapArray elements.
            for (int i=0; i<=bound0; i++)
            {
                for (int j=0; j<=bound1; j++)
                {
                    int value = mapArray[i, j];
                    Console.WriteLine(value);
                }
            }
        }
    }
