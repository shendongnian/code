    public static object[,] Convert(DataTable dt)
    {
        var rows = dt.Rows;
        int rowCount = rows.Count;
        int colCount = dt.Columns.Count;
        var result = new object[rowCount, colCount];
        for (int i = 0; i < rowCount; i++)
        {
            var row = rows[i];
            for (int j = 0; j < colCount; j++)
            {
                result[i, j] = row[j];
            }
        }
        return result;
    }
