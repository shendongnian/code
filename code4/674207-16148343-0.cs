    foreach (var childOrg in viewModel.ChildOrganizations)
    {
        var childOrgUsers = new HashSet<OrganizationUserViewModel>();
        var users = this._organizationManager.GetOrganizationUsers(childOrg.OrganizationId);
        foreach (var user in users)
        {
            var userViewModel = Gateway.Instance.Map<User, OrganizationUserViewModel>(user.User);
            userViewModel.Organization_UserId = user.Organization_UserId;
            if (selectedUsers != null)
            {
                foreach (OrganizationUserViewModel selectedUser in selectedUsers)
                {
                    if (selectedUser.UserId != userViewModel.UserId)
                    {
                        childOrgUsers.Add(userViewModel);
                    }
                }
            }
        }
        childOrg.Users = childOrgUsers.ToList();
    }
