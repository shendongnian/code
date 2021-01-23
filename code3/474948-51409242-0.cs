    if(gridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending)
    {
         // you can ascending if you want
         gridView1.Sort(gridView1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
    }
    else
    {
          // you can descending if you want
         gridView1.Sort(gridView1.Columns[e.ColumnIndex], ListSortDirection.Descending);
    }
    
    
