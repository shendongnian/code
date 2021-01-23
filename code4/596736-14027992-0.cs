    protected void Page_Load(object sender, EventArgs e)
    {
        int numPages = 3, numItems = 10;
        int[] parentRepeatCnt = Enumerable.Range(0, numPages).ToArray();
        int[] childRepeatCnt = Enumerable.Range(0, numItems).ToArray();
        ParentRepeater.DataSource = parentRepeatCnt;
        ParentRepeater.DataBind();
        foreach (int i in parentRepeatCnt)
        {
            Repeater ChildRepeater = ParentRepeater.Items[i].FindControl("ChildRepeater") as Repeater;
            ChildRepeater.DataSource = childRepeatCnt;
            ChildRepeater.DataBind();
        }
    }
    public void ChildRepeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Label Label1 = e.Item.FindControl("Label1") as Label;
            // access DataTable here
            Label1.Text = myDataTable.Rows[0]["item"].ToString();
        }
    }
}
