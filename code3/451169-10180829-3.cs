    var chkList = PlaceHolder.FindControl("chkList1") as CheckBoxList;
    if (chkList != null)
    {
        foreach (ListItem item in chkList.Items)
        {
            if (item.Selected)
            {
            }
        }
    }
