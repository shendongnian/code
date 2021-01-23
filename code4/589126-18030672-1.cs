    protected void RadListView1_ItemCommand(object sender,Telerik.Web.UI.RadListViewCommandEventArgs e)
    {
        CheckBox button = (CheckBox)e.ListViewItem.FindControl("CheckBox1");
        if (e.CommandName == "Approve")
        {
            if (button.Checked == true)
            {
               //your code
            }
            else
            {
               //your code
            }
        }
    }
