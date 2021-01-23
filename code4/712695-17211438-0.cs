        StringBuilder sb = new StringBuilder();
        foreach (DataRow row in schemaTable.Rows)
        {
            sb.AppendLine("Data for table: " + row["ColumnName"].ToString());
            foreach (DataColumn column in schemaTable.Columns)
            {
                sb.AppendLine(column.ColumnName + ":"  +row[column.ColumnName].ToString());
            }
            sb.AppendLine();
        }
        File.WriteAllText(@"C:\Users\Manuela\Documents\GL4\WriteLines.txt", sb.ToString());
