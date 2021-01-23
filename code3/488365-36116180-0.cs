    public static void FromListView(DataTable table, ListView lvw)
    {
       table.Clear();
       var columns = lvw.Columns.Count;
       foreach (ColumnHeader column in lvw.Columns)
          table.Columns.Add(column.Text);
       foreach (ListViewItem item in lvw.Items)
       {
          var cells = new object[columns];
          for (var i = 0; i < columns; i++)
             cells[i] = item.SubItems[i].Text;
          table.Rows.Add(cells);
       }
    }
