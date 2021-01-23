    protected void grd_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
         GridViewRow row = grd.Rows[e.RowIndex];
         for (int i = 0; i <= row.Cells.Count; i++)
         {
             String str = ((TextBox)(row.Cells[i].Controls[0])).Text;
             if (!string.IsNullOrEmpty(str))
             { 
              //Your Code goes here ::
             }
         }
    }
