    void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "checkboxcolumn")
        {
            Console.WriteLine("Click");
            bool isChecked = (bool)dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
            dataGridView1.EndEdit();
        }
    }
