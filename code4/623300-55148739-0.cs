      protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           Control ctrl = e.CommandSource as Control;  
           if (ctrl != null)
           {
               GridViewRow gvRow = ctrl.Parent.NamingContainer as GridViewRow; 
               Label slno = (Label)gvRow.FindControl("slno");  // Find Your Control here
               TextBox txtno = (TextBox)gvRow.FindControl("txtno");  // Find Your Control here
               // Your work start here
           }
        }
