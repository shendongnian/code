    public static T[,] To2DArray<T>(this IEnumerable<T> items, int rows, int columns)
    {
        var matrix = new T[rows, columns];
        int row = 0;
        int column = 0;
        foreach (T item in items)
        {
            matrix[row, column] = item;
            ++column;
            if (column == columns)
            {
                ++row;
                column = 0;
            }
        }
        return matrix;
    }
