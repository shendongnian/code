    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // If the column is the Artist column, check the
        // value.
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Artist")
        {
            if (e.Value != null)
            {
                // Check for the string "pink" in the cell.
                string stringValue = (string)e.Value;
                stringValue = stringValue.ToLower();
                if ((stringValue.IndexOf("pink") > -1))
                {
                    e.CellStyle.BackColor = Color.Pink;
                }
    
            }
        }
        else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
        {
            ShortFormDateFormat(e);
        }
    }
