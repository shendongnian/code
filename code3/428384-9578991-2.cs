    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptDemo = sender as Repeater; // Get the Repeater control object.
       
        // If the Repeater contains no data.
        if (repeaterTopItems != null && repeaterTopItems.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                // Show the Error Label (if no data is present).
                Label lblErrorMsg = e.Item.FindControl("lblErrorMsg") as Label;
                if (lblErrorMsg != null)
                {
                    lblErrorMsg.Visible = true;
                }
            }
        }
    }
