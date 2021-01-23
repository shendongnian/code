    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            LinkButton link = (LinkButton)gridDataItem["ContentTitle"].Controls[0];
            link.Click += dummyBtn_Click;
        }
    }
    
    protected void dummyBtn_Click(object sender, EventArgs e)
    {
        Response.Write("dummyBtn_Click");
    }
