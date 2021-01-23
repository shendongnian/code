    public static Tuple<int,int> PositionOf<T>(this List<List<T>> matrix, T toSearch)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            int colIndex = matrix[i].IndexOf(toSearch);
            if (colIndex >= 0 && colIndex < matrix[i].Count)
                return Tuple.Create(i, colIndex);
        }
        return Tuple.Create(-1, -1);
    }
