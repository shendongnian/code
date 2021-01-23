     protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
     {
       gv.EditIndex = -1;
       GridViewRow gvRow= (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            
     
      foreach (TableCell Tc in gvRow.Cells)
                {
                   //if you are not getting value than find childcontrol of TabelCell.
                    string sss = c.Text;
                    foreach (Control ctl in Tc.Controls)
                    {
                       
                        //Child controls
                        Label lb = ctl as Label;
                        string s = lb.Text;
                        sb.Append(s + ',');
                    }
                }
    }
   
