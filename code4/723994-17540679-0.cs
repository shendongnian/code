    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Int64 forumId = Convert.ToInt64(GridView1.SelectedRow.Cells[1].Text);
            Session["forumId"] = forumId;
            Response.Redirect("Thread.aspx");
        }
        catch (Exception)
        {
            throw;
        }
    }
