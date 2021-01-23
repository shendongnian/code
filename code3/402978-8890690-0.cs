    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewHelper helper = new GridViewHelper(this.GridView1);
        helper.RegisterGroup("yourGroupName", true, true);
        helper.GroupHeader += new GroupEvent(helper_GroupHeader);
    }
        
    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
    {
        if (groupName == "yourGroupName" )
        {
            row.Cells[0].Text = "<br />" + row.Cells[0].Text;
        }
    } 
