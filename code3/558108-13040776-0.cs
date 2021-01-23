     private System.Data.DataTable CreateDataTable(List<string> columnDefinitions, List<List<string>> rows)
        {
            DataTable table = new DataTable();
            
            foreach (string colDef in columnDefinitions)
            {
                DataColumn column;
                column = new DataColumn();
                column.DataType = typeof(string);
                column.ColumnName = colDef;
                table.Columns.Add(column);
            }
           
            for (int i = 0; i < rows[0].Count; i++)
            {
                table.Rows.Add(rows[0][i], rows[1][i], rows[2][i], rows[3][i], rows[4][i], rows[5][i], rows[6][i]);
            }
            return table;
        }
        private List<string> GetColDefsFromBackend()
        {
            List<string> cols = new List<string>();
            cols.Add("Monday");
            cols.Add("Tuesday");
            cols.Add("Wednesday");
            cols.Add("Thursday");
            cols.Add("Friday");
            cols.Add("Saturday");
            cols.Add("Sunday");
            return cols;
        }
