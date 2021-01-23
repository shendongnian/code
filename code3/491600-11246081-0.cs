    ...
    if (e.Item.ItemIndex == 0)
    {
        Button b = e.Item.FindControl("btnmoveup") as Button;
        // IS NOT admin AND IS project owner will set .Enabled = true
        b.Enabled = (!isAdmin && isProjectOwner);
    }
