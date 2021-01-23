      for (int row = 0; row < xlRange.Rows.Count; row++)
        {
            DataRow dataRow = null;
            if (row != 0) dataRow = excelTb.NewRow();
            for (int col = 0; col < xlRange.Columns.Count; col++)
            {
                if (row == 0) //Headers
                {
                    excelTb.Columns.Add(xlRange.Cells[row + 1, col + 1].Value2.ToString());
                }
                else //Data rows
                {
                    dataRow[col] = xlRange.Cells[row + 1, col + 1].Value2.ToString();
                }
            }
        }
