    for (int i = 0; i < RolesList.Items.Count; i++)
    {
        if (User.IsInRole(RolesList.Items[i].Value))
           RolesList.Items[i].Selected = true;
    }
