     protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
          GridView gv = (GridView)sender;
          GridViewRow gvr = (GridViewRow)gv.Rows[e.RowIndex];
          Label lbl = (Label)gvr.FindControl("Label1");
          string s = lbl.Text;
     }
