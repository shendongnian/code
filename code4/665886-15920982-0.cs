    private void grdData_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
       if (e.ColumnIndex == 4)
       {
           if(grdData.Rows[e.RowIndex].Cells[5].Value == null)  // check using debugger if the value is null or maybe it can be an empty string
           {
               grdData.ClearSelection(); 
               grdData.Rows[e.RowIndex].Cells[4].Selected = true;
           }
       }
    }
