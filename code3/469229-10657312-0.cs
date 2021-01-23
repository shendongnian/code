    foreach (string item in ddlReferring.Items)
    {
        if (item.StartsWith(firstStart))
        {
            ddlReferring.SelectedText = item;
            break;
        }
    }
