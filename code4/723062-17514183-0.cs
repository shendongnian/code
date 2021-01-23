    class Matrix : IEnumerable<double>
    {
        double[,] input;
        public Matrix(double[,] inputArray)
        {
            input = inputArray;
        }
        public IEnumerator<double> GetEnumerator()
        {
            return (IEnumerator<double>)input.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return input.GetEnumerator();
        }
    }
