    void listView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
       listView.ItemCheck -= listView_ItemCheck;
       // Determine whether the column is the same as the last column clicked.
       if (e.Column != sortColumn)
       {
          
          // Set the sort column to the new column.
          sortColumn = e.Column;
          // Set the sort order to ascending by default.
          listView.Sorting = SortOrder.Ascending;
       }
       else
       {
          // Determine what the last sort order was and change it.
          if (listView.Sorting == SortOrder.Ascending)
             listView.Sorting = SortOrder.Descending;
          else
             listView.Sorting = SortOrder.Ascending;
       } 
       listView.ItemCheck += listView_ItemCheck;
    }
