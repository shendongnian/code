            protected void lbp10_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = (GridView1.PageIndex - 10);
        bind();
    }
    protected void lbp_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = (GridView1.PageIndex - 1);
        bind();
    }
    protected void lbn_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = (GridView1.PageIndex + 1);
        bind();
    }
    protected void lbn10_Click(object sender, EventArgs e)
    {
        GridView1.PageIndex = (GridView1.PageIndex + 10);
        bind();
    }
    protected void lb1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridView1.PageIndex = (int.Parse(lb.Text) - 1);
        bind();
    }
