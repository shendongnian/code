    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            { 
                 foreach (GridViewRow gvr in GridView1.Rows)
                    {
                           foreach (Control ctrl in gvr.Controls)   
                         {
                              Label lbl = (Label )e.Row.FindControl("yourlabel");
                              lbl.ForeColor =system.drawing.color.red;
        
                            }
                   }
            }
