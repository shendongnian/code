    private void grdData_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
       if (e.ColumnIndex == 4)
       {
           if(grdData.Rows[e.RowIndex].Cells[4].Value.Equals(""))  
           {
               grdData.ClearSelection(); 
               grdData.Rows[e.RowIndex].Cells[4].Selected = true;
           }
       }
    }
