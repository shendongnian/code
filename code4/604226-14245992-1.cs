    public IEnumerable<User> ReturnUsersNotInRoles()
    {
        var z = (from users
                        //...many joins..conditions...
                        ).Distinct().Include(x => x.RoleUserLinks);
    
    	var addedLinkStatusID = (int)Enums.LinkStatus.Added;
        return z.Where(user => 
    			   false == user.RoleUserLinks.Any(link => link.LinkStatusID == addedLinkStatusID))
                .ToList();
    }
