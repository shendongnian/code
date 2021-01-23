    class testclass
    {
        public testfunction(double[,] values)
        {
            double[][] rawData = new double[10][];  
            for (int i = 0; i < 10; i++)
            {
            rawData[i] = new double[] { values[i, 2], stockvalues[i, 0] };  // if data won't fit into memory, stream through external storage
            }
            int num = 3;  
            int max = 30; 
        } 
        public int[] checkvalue(double[][] rawData, int num, int maxCount) 
        {
            ............
        }
    }
