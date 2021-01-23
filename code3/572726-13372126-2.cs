     private void DataGrid_KeyDown(object sender, KeyEventArgs e)
     {
       if (e.KeyCode == Keys.Delete)
       {
        Int32 selectedRowCount =  DataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
        if (selectedRowCount > 0)
         {
            for (int i = 0; i < selectedRowCount; i++)
            {
                DataGrid.Rows.RemoveAt(DataGrid.SelectedRows[0].Index);  
            }
         }
       }
    }
