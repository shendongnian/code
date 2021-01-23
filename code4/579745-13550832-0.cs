        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)GridView1.Rows[e.RowIndex];
            string id = String.Empty;
            Label lbl = (gvr.FindControl("Label1") as Label)
            if (lbl != null)
            {
              id = lbl.Text;
            }
        } 
