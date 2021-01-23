    protected void btnGetID_Click(object sender, e as EventArgs)
    {
        //sender is the button
        Button btnGetID = (Button)sender;
        //the button's parent control is the RepeaterItem
        RepeaterItem theItem = (RepeaterItem)sender.Parent;
        //find the hidden field in the RepeaterItem
        HiddenField hidID = (HiddenField)theItem.FindControl("hidID");
        //assign to variable
        string strID = hidID.Value;
    }
