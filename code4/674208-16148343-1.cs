    foreach (var childOrg in viewModel.ChildOrganizations)
    {
    	var allUserId = new HashSet<int>();
        var users = this._organizationManager.GetOrganizationUsers(childOrg.OrganizationId);
        foreach (var user in users)
        {
            var userViewModel = Gateway.Instance.Map<User, OrganizationUserViewModel>(user.User);
            userViewModel.Organization_UserId = user.Organization_UserId;
    		allUserId.Add(userViewModel.UserId);
        }
    	
    	var childOrgUsers = new List<OrganizationUserViewModel>();
    	if (selectedUsers != null)
    	{
    		foreach (OrganizationUserViewModel selectedUser in selectedUsers)
    		{
    			if(allUserId.Contains(selectedUser.UserId) == false)
    			{
    				childOrgUsers.Add(userViewModel);
    			}
    		}
    	}
        childOrg.Users = childOrgUsers;
    }
