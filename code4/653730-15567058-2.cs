    if (e.Item is GridDataItem && e.Item.IsInEditMode)
    {
        GridDataItem edititem = (GridDataItem)e.Item;
        TextBox txtpwd = (TextBox)edititem["Pin"].Controls[0];
        txtpwd.TextMode = TextBoxMode.Password;
        txtpwd.Visible = true;
    }
