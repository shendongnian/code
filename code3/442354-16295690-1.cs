    var sb = new StringBuilder();
    var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
    sb.Append(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"")));
    sb.AppendLine();
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        var cells = row.Cells.Cast<DataGridViewCell>();
        sb.Append(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"")));
        sb.AppendLine();
    }
