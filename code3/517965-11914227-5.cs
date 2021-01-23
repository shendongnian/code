    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {        
        if (dataGridView1.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.AllCells)
        {
            // Loop over all the columns
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                // Work out the size of the header text
                Size s = TextRenderer.MeasureText(c.HeaderText, dataGridView1.Font);
                
                // Change the autosize mode to allow us to see if the header cell has the 
                // longest text
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                if (s.Width + 10 > c.Width)
                {
                    // If the header cell is longest we set the column width
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    c.Width = s.Width + 10;
                }
                else
                {
                    // If the header cell is not longest, reset the autosize mode
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
    }
