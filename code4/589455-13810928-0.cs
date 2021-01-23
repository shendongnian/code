                DataTable myDataTable = new DataTable();
                //adding Columns
                myDataTable.Columns.Add("colInt", typeof(int));
                myDataTable.Columns.Add("colDate", typeof(DateTime));
                myDataTable.Columns.Add("colString", typeof(string));
    
                //adding Rows
                myDataTable.Rows.Add(1, DateTime.Now, "Hello World");
                
                //to get columns
                foreach (DataColumn col in myDataTable.Columns)
                {
                    var c = new DataGridViewTextBoxColumn() { HeaderText = col.ColumnName }; //Let say that the default column template of DataGridView is DataGridViewTextBoxColumn
                    dataGridView1.Columns.Add(c);
                }
        
                //to get rows
                foreach (DataRow row in myDataTable.Rows)
                {
                    dataGridView1.Rows.Add(row[0], row[1], row[2]);
                }
