    if (listView1.SelectedItems.Count > 0)
    {
         foreach (DataRowView drv in listView1.SelectedItems)
         {
             string firstColumn = drv.Row[0] != null ? drv.Row[0].ToString() : String.Empty;
             string secondColumn = drv.Row[1] != null ? drv.Row[1].ToString() : String.Empty;
             // ... do something with these values before they are replaced
             // by the next run of the loop that will get the next row
         }
    }
