        public static System.Data.DataTable ArrayToDataTable(Array array, bool headerQ=true)
        {
            if (array == null || array.GetLength(1) == 0 || array.GetLength(0) == 0) return null;
            System.Data.DataTable dt = new System.Data.DataTable();
            int dataRowStart = headerQ ? 1 : 0;
            // create columns
            for (int i = 1; i <= array.GetLength(1); i++)
            {
                var column = new DataColumn();
                string value = array.GetValue(1, i) is System.String
                    ? array.GetValue(1, i).ToString() : "Column" + i.ToString();
                column.ColumnName = value;
                dt.Columns.Add(column);
            }
            if (array.GetLength(0) == dataRowStart) return dt;  //array has no data
            //Note:  the array is 1-indexed (not 0-indexed)
            for (int i = dataRowStart + 1; i <= array.GetLength(0); i++)
            {
                // create a DataRow using .NewRow()
                DataRow row = dt.NewRow();
                // iterate over all columns to fill the row
                for (int j = 1; j <= array.GetLength(1); j++)
                {
                    row[j-1] = array.GetValue(i,j);
                }
                // add the current row to the DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
