    private void lstSecurityGroups_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        LinkDescriptor linkDescriptor = _ctx.GetLinkDescriptor(user, "SecurityGroups", securityGroup);
        if (linkDescriptor != null)
        {
            linkDescriptor.State = EntityStates.Unchanged;
        }
        if (e.NewValue == CheckState.Unchecked)
        {
            _ctx.DeleteLink(user, "SecurityGroups", securityGroup);
        }
        else if (e.NewValue == CheckState.Checked)
        {
            _ctx.AddLink(user, "SecurityGroups", securityGroup);
        }
    }
