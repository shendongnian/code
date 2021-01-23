    protected void cmdRefresh_Click(object sender, EventArgs e)
    {
        MasterDetail.EnableCaching = false;
        GridView1.DataBind();
        MasterDetail.EnableCaching = true;
    }
