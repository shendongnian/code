            DataTable table = new DataTable();
            //DataRow[] rowArray = dataTable.Select();
            table = dataTable.Clone();
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                table.ImportRow(dataTable.Rows[i]);
            }
            return table;
 
