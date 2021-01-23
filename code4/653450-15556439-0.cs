    public static T[][] GetPlane<T>(T[, ,] source, int secondDimensionValue)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(i => Enumerable.Range(0, source.GetLength(2))
                .Select(j => source[i, secondDimensionValue, j])
                .ToArray())
            .ToArray();
    }
