    private double[,] general_foo(double[,] a, int dimension)
    {
        var w = a.GetLength(0);
        var h = a.GetLength(1);
        var result = new double[w, h];
        var otherDimension = 1 - dimension; // NOTE only works for 2D arrays
        var otherDimensionLength = a.GetLength(otherDimension);
        var dimensionLength = a.GetLength(dimension);
        for (int i = 0; i < dimensionLength; i++)
        {
            for (int j = 0; j < otherDimensionLength; j++)
            {
                var setIndexes = new int[2] { j, j };
                setIndexes[dimension] = i;
                var beforeIndexes = new int[2] { j, j };
                beforeIndexes[dimension] = Math.Max(i - 1, 0);
                var afterIndexes = new int[2] { j, j };
                afterIndexes[dimension] = Math.Min(i + 1, dimensionLength - 1);
                var beforeValue = (double)a.GetValue(beforeIndexes);
                var afterValue = (double)a.GetValue(afterIndexes);
                result.SetValue((afterValue - beforeValue) * 0.5, setIndexes);
            }
        }
        return result;
    } 
