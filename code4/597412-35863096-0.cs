    private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        DataGridViewColumn column = Grid.Columns[e.ColumnIndex];
        if (column.DataPropertyName.Contains("."))
        {
            object data = Grid.Rows[e.RowIndex].DataBoundItem;
            string[] properties = column.DataPropertyName.Split('.');
            for (int i = 0; i < properties.Length && data != null; i++)
                data = data.GetType().GetProperty(properties[i]).GetValue(data);
            Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
        }
    }
