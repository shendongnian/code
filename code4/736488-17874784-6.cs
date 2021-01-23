     protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
          GridView gv = (GridView)sender;
          GridViewRow gvr = (GridViewRow)gv.Rows[e.RowIndex];
          TextBox TxtRejectReason= (TextBox)gvr.FindControl("TxtRejectReason");
          string s = TxtRejectReason.Text;
          GridView.EditIndex = -1;
          GridView.DataBind();
     }
