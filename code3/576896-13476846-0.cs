    public DataTable createdatatablefromdgv()
    {
       DataTable dsptable = new DataTable();
       for (int i = 0; i < dataGridView1.Columns.Count; i++)
       {
           DataColumn dspcolumn = new DataColumn(dataGridView1.Columns[i].HeaderText);
           dsptable.Columns.Add(dspcolumn);
       }
       int noOfColumns = dataGridView1.Columns.Count;
       foreach (DataGridViewRow dgvr in dataGridView1.Rows)
       {
           DataRow dataRow = dsptable.NewRow();
           for (int i = 0; i < noOfColumns; i++)
           {
               dataRow[i] = dgvr.Cells[i].Value.ToString();
           }
           dsptable.Rows.Add(dataRow); //Add this statement to add rows to Data Table
       }
       return dsptable;
    }
     
