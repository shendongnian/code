    public void delete_Onclick(object sender, EventArgs e) {
        var btn = (Button)sender;
        var item = (ListViewItem)btn.NamingContainer;
        // find other controls:
        var btnModify = (Button)item.FindControl("modify");
    }
