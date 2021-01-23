    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        foreach (DataColumn column in dv.Table.Columns)
        {
            sb.AppendFormat("{0} Like '%{1}%' OR ", column.ColumnName, txtSearch.Text);
        }
        sb.Remove(sb.Length - 3, 3);
        dv.RowFilter = sb.ToString();
        dgClientMaster.DataSource = dv;
    }
