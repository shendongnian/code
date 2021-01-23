    protected void AddNews_Click(object sender, EventArgs e)
    {
        int index = GridView1.SelectedIndex;
        if(index >= 0) // if -1 no selection 
        {
            Response.Redirect("~/AddNews.aspx?Parameter=" + index);
        }
    }
