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
            for (int variable1=0; variable1<=bound0; variable1++)
            {
                for (int variable2=0; variable2<=bound1; variable2++)
                {
                    int value = mapArray[variable1, variable2];
                    Console.WriteLine(value);
                }
            }
        }
    }
