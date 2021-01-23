    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
        
        if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
        {
            string entry = "";
            if (cell.Value != null)
            {
                entry = cell.Value.ToString();
            }
            MessageBox.Show(entry);
            MakeTextFeet(entry);
        }
    }
