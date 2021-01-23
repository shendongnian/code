    private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
    {
       if (e.ColumnIndex == 5)
       {
           if(grdData.Rows[e.RowIndex].Cells[3].Value.Equals(""))  
           {
               grdData.ClearSelection(); 
               grdData.Rows[e.RowIndex].Cells[3].Selected = true;
           }
       }
    }
