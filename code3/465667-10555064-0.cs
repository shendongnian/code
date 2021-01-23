    IEnumerable<IEnumerable<int>> Transpose(IEnumerable<IEnumerable<int>> collection)
    {
        var width = collection.First().Count();
        var flattened = collection.SelectMany(c => c).ToArray();
        var height = flattened.Length / width;
        var result = new int[width][];
        for (int i = 0; i < width; i++)
        {
            result[i] = new int[height];
            for (int j = i, k = 0; j < flattened.Length; j += width, k++)
                result[i][k] = flattened[j];
        }
        return result;
    }
