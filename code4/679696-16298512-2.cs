    public static TOutput[,] ConvertAll<TInput, TOutput>(TInput[,] array, Func<TInput, TOutput> converter)
    {
        int xMin = array.GetLowerBound(0);
        int xLen = array.GetLength(0);
        int yMin = array.GetLowerBound(1);
        int yLen = array.GetLength(1);
        var result = (TOutput[,])Array.CreateInstance(typeof(TOutput), new[] { xLen, yLen, }, new[] { xMin, yMin, });
        for (int x = xMin; x < xMin + xLen; ++x)
            for (int y = yMin; y < yMin + yLen; ++y)
                result[x, y] = converter(array[x, y]);
        return result;
    }
