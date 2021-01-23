    public static string ToMatrixString<T>(this T[,] matrix, string delimiter = "\t")
    {
        var s = new StringBuilder();
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                s.Append(matrix[i, j]).Append(delimiter);
            }
            s.AppendLine();
        }
        return s.ToString();
    }
