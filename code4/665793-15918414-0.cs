    protected void AddNews_Click(object sender, EventArgs e)
    {
        int i = GridView1.SelectedRow.RowIndex;
        if(i>= 0)
        {
            Response.Redirect("~/AddNews.aspx?Parameter=" + index);
        }
    }
