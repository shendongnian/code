    public void GetMax()
    {
        var a = new[]
                    {
                        new[] {1, 202, 4, 55},
                        new[] {40, 7},
                        new[] {2, 48, 5},
                        new[] {40, 8, 90}
                    };
        var result = GetMaxRecursive(a, 0);
    }
    private static int[][] GetMaxRecursive(int[][] matrix, int level)
    {
        // get max value at this level
        var maxValue = matrix.Max(array => array.Length > level ? int.MinValue : array[level]);
            
        // get all int array having max value at this level
        int[][] arraysWithMaxValue = matrix
            .Where(array => array.Length > level && array[level] == maxValue)
            .ToArray();
            
        return arraysWithMaxValue.Length > 1
                    ? GetMaxRecursive(arraysWithMaxValue, ++level)
                    : arraysWithMaxValue;
    }
