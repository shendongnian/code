    foreach (Control c in MainPanel.Controls)
    {
        DropDownList list = c as DropDownList;
        if (list != null)
        {
            list.Items.Clear();
        }
    }
