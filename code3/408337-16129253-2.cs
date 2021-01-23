     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string id = e.Row.Cells[2].Text;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton db = (LinkButton)e.Row.Cells[6].Controls[0];
                db.OnClientClick = "return confirm('Are you want to delete this Work Description : " + id + "?');";
            }
        }
