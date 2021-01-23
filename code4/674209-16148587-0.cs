    foreach (var childOrg in viewModel.ChildOrganizations)
    {
        List<OrganizationUserViewModel> childOrgUsers = new List<OrganizationUserViewModel>();
        var users = this._organizationManager.GetOrganizationUsers(childOrg.OrganizationId);
        foreach (var user in users)
        {
            var userViewModel = Gateway.Instance.Map<User, OrganizationUserViewModel>(user.User);
            userViewModel.Organization_UserId = user.Organization_UserId;
            if (selectedUsers != null)
            {
                var foundUser = selectedUsers.FirstOrDefault(x => x.UserId == userViewModel.UserId);
    			
    			if(foundUser == null)
    			{
    				childOrgUsers.Add(userViewModel);
    			}
            }
        }
        childOrg.Users = childOrgUsers.Distinct().ToList();
    }
