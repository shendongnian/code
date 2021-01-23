    class Program
    {
        static void Main(string[] args)
        {
            var data = new[,]
            {
                { 1.1, 2.2 }, 
                { 3.3, 4.4 }, 
                { 5.5, 6.6 }, 
                { 7.7, 8.8 }
            };
    
            double meanValue = Mean(data, 0);
        }
    
        public static double Mean(double[,] data, int columnIndex)
        {
            double sum = 0.0;
            int rowsCount = data.GetLength(0);
    
            for (int i = 0; i < rowsCount - 1; i++)
            {
                sum += data[i, columnIndex];
            }
    
            return sum / rowsCount;
        }
    }
