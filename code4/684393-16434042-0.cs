            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn() { DataType = typeof(int) });
            dt.Columns.Add(new DataColumn() { DataType = typeof(int) });
            dt.Columns.Add(new DataColumn() { DataType = typeof(string) });
            dt.Rows.Add(dt.NewRow());
            dt.Rows.Add(dt.NewRow());
            dt.Rows.Add(dt.NewRow());
            dt.Rows.Add(dt.NewRow());
            int RowId = 0, 
                ColId = 0;
            //Cell access example
            var Cell = dt.Rows[RowId][ColId];
