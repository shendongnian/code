    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       IList lst = (IList)Session["lst"];
       lst .RemoveAt(e.RowIndex);
        GridView1.DataSource = lst ;
        GridView1.DataBind();
    }
