    foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    String header = dataGridView1.Columns[i].HeaderText;
                    //String cellText = row.Cells[i].Text;
                    DataGridViewColumn column = dataGridView1.Columns[i]; // column[1] selects the required column 
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // sets the AutoSizeMode of column defined in previous line
                    int colWidth = column.Width; // store columns width after auto resize           
                    colWidth += 50; // add 30 pixels to what 'colWidth' already is
                    this.dataGridView1.Columns[i].Width = colWidth; // set the columns width to the value stored in 'colWidth'
                }
            }
