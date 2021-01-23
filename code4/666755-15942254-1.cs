         foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    dt.Columns.Add(new DataColumn(c.HeaderText.ToString()));
                }
    
    
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                // create a new dt row to match up with the rows in the DGV
                DataRow dr = dt.NewRow();
                int column = 0;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    //Sure you can see what this is doing.
                    dr[c.HeaderText.ToString()] = dataGridView1.Rows[row].
                       Cells[column].Value;
                    column++;
                }
    
                //now i add the row to the data table.
                dt.Rows.Add(dr);
            }
    
            
            dataGridView1.Rows.Clear();
     dt = dt.Select("Type='1301'").CopyToDataTable();
                dataGridView1.DataSource = dt;
        
