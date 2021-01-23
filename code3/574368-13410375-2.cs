    cmbJoinColumn.Items.Clear() //If you want to remove previous Items.
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
