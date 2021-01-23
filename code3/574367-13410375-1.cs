    cmbJoinColumn.Items.Clear() //optional
    for(int intCount = 0; intCount < lbFirstTableColumns.Items.Count;intCount++)
      {
           for(int intSubCount = 0;intSubCount < lbSecondTableColumns.Items.Count; intSubCount++)
           {
                if (lbSecondTableColumns.Items[intCount].ToString() == lbSecondTableColumns.Items[intSubCount].ToString())
                 {
                      cmbJoinColumn.Items.Add(lbSecondTableColumns.Items[intCount].ToString());
                 }
           }
     }
