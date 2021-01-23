    foreach (RepeaterItem repeaterItem in repCheckboxes.Items)
    {
        HtmlInputCheckBox listItem = (HtmlInputCheckBox)repeaterItem.FindControl("ck");
        if (listItem.Checked)
        {
             string val = listItem.Value;
             ...
