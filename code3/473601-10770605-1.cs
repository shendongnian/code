    public class MatrixGenerator: IMatrixGenerator
    {
        // ...
        Random r = new Random();
        // ...
        public void Next()
        {
            _matrix = new double[vSize, hSize];
            _right = new double[vSize];
            _solution =  Enumerable.Repeat(new Random(), hSize)
                                   .Select(r => r.NextDouble() * maxValue)
                                   .ToArray(); 
            // ...
