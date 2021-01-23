    var sb = new StringBuilder();
    var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
    sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"")));
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        var cells = row.Cells.Cast<DataGridViewCell>();
        sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"")));
    }
