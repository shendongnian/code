    //This will try hiding the column at index 1
    listView1.Columns[1].Width = 0;
    //ColumnWidthChanging event handler of your ListView
    private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e){
      if(e.ColumnIndex == 1){
         e.Cancel = true;
         e.NewWidth = 0;
      }
    }
