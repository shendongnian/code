        public static void Ignore_Names(DataSet sheet) {
            var table = sheet.Tables[0];
            var columns = table.Columns;
            var nameColumn = columns["Name"];
 
            var names = new List<string>();
            foreach (DataRow row in nameColumn.Table.Rows)
                names.Add(row[0].ToString().ToLower());
 
            // Work from right to left.  If you delete column 3, is column 4 now 3, or still 4?  This fixes that issue.
            for (int i = columns.Count - 1; i >= 0; i--)
                if (!names.Contains(columns[i].ColumnName.ToLower()))
                    columns.RemoveAt(i);
        }
 
