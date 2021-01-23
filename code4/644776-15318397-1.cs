    public class Matrix : List<MatrixEntry>
        {
        }
    
        public class MatrixEntry
        {
            public double Price { get; private set; }
    
            public double Value1
            {
                get { return (Price - 0.5); }
            }
    
            public double Value2
            {
                get { return (Price - 0.25); }
            }
    
            public double Value3
            {
                get { return Price; }
            }
    
            public double Value4
            {
                get { return (Price + 0.25); }
            }
    
            public double Value5
            {
                get { return (Price + 0.5); }
            }
    
            public MatrixEntry(double price)
            {
                Price = price;
            }
        }
    static Matrix GetMatrixCalcGrid()
            {
                var matrix = new Matrix();
    
                try
                {
                    double minValue = 1;
                    double maxValue = 2;
                    double incrementValue = .25;
    
                    for (double i = minValue; i < maxValue + incrementValue; i += incrementValue)
                    {
                        var entry = new MatrixEntry(i);
                        matrix.Add(entry);
                    }
    
                }
                catch (Exception ex) { Console.WriteLine("! " + ex); }
                finally { }
    
                return matrix;
            }
