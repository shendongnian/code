    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "CustomerID")
        {
            if (int.Parse(e.Value.ToString()) == 1)
            {
                e.Value = "x";
            }
            else if (int.Parse(e.Value.ToString()) == 3)
            {
                e.Value = "y";
            }
        }
    }
