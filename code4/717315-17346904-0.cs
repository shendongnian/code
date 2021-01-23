    public static void YourProcessName(DataTable dt, string columnName, int maxRows)
    {
        var rcount = dt.Rows.Count;
        while (rcount < maxRows)
        {
            var max = (dt.Rows.Count - 1) * 2;
            for (var i = 0; i < max; i += 2)
            {
                var avg = ((double)dt.Rows[i][columnName] + (double)dt.Rows[i + 1][columnName]) / 2;
                var nRow = dt.NewRow();
                nRow[columnName] = avg;
                dt.Rows.InsertAt(nRow, i + 1);
                rcount++;
                if (rcount == maxRows) break;
            }
        }
    }
