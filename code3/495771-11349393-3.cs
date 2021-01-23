    private void lstSecurityGroups_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Unchecked)
        {
            _ctx.DetachLink(user, "SecurityGroups", securityGroup);
        }
        else if (e.NewValue == CheckState.Checked)
        {
            _ctx.AddLink(user, "SecurityGroups", securityGroup);
        }
    }
