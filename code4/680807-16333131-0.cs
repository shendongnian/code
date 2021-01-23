        DataColumnCollection columns = dt.Columns;
        DataRowCollection rows = dt.Rows;
        foreach (DataColumn column in columns)
        {
            textBox1.AppendText(column.ColumnName + ": ");
            foreach (DataRow row in rows)
            {
                //display the cell value
                textBox1.AppendText(row[column.ColumnName].ToString());
            }
            textBox1.AppendText(Environment.NewLine);
        }
