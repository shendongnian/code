    if (listView1.Items.Count > 0)
    {
           dt.Columns.Add();
           foreach (ListViewItem.ListViewSubItem lvsi in listView1.Items[0].SubItems)
                  dt.Columns.Add();
           //now we have all the columns that we need, let's add rows
           foreach (ListViewItem item in listView1.Items)
           {
                  List<string> row = new List<string>();
                  row.Add(item.ToString());
                  foreach (var it in item.SubItems)
                       row.Add(it.ToString());
                  //Add the row into the DataTable
                  dt.Rows.Add(row.ToArray());
           }
    }
