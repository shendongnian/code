    var data = mg.DatabaseTable.Where(m => m.UserName.StartsWith(TextBoxUserID.Text) &&
                                           m.Action.StartsWith(DropDownListStatus.Text) &&
                                           m.Site.Contains(TextBoxSite.Text));
    if (searchMode == StartsWith)
    {
        return data.Where(m => m.Content.StartsWith(TextBoxBarcode.Text);
    }
    else if (searchMode == EndsWith)
    {
        return data.Where(m => m.Content.EndsWith(TextBoxBarcode.Text);
    }
    else
    {
        return data.Where(m => m.Content.Contains(TextBoxBarcode.Text);
    }
