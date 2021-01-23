    StringBuilder sb = new StringBuilder();
    foreach (DataGridViewColumn column in DGridView_Main.Columns)
    {
      sb.AppendFormat("CONVERT({0}, System.String) LIKE '%{1}%' OR ", column.Name, TxtBx_FilterKeywordForGridView.Text);
    }
    sb.Remove(sb.Length - 3, 3);
    (DGridView_Main.DataSource as DataTable).DefaultView.RowFilter = sb.ToString();    
