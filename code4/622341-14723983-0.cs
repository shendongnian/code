    foreach (ListViewItem item in listView.Items)
    {
        LinkButton linkButton = item.FindControl("LinkButton1") as LinkButton;
        if (linkButton != null)
            linkButton.Visible = false;
    }
