    private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
         var dgv = sender as DataGridView;
         var check = dgv[e.ColumnIndex, e.RowIndex].Value as bool?;
    
         if (check.HasValue)
         {
             if (check) 
             {
                 //checked
             }
             else
             {
                 //unchecked
             }
         }
    }
