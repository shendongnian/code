    public static TOutput[,] ConvertAll<TInput, TOutput>(TInput[,] array, Func<TInput, TOutput> converter)
    {
        var result = new TOutput[array.GetLength(0), array.GetLength(1)];
        for (int i = 0; i < array.GetLength(0); ++i)
            for (int j = 0; j < array.GetLength(1); ++j)
                result[i, j] = converter(array[i, j]);
        return result;
    }
