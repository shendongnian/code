    protected void  GWCase_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.DataItem != null)
            {
                Label5.Text  = e.Row.Cells[1].Text;
              
            }   
        }
