    public int CopyMembershipUsersToUserEntities()
    {
        int lastID = _entities.Max(x => x.ID_client); 
        foreach (MembershipUser member in Membership.GetAllUsers()) 
        { 
            UserEntity entity = new UserEntity(); 
            entity.Username = member.UserName; 
            entity.Roles = "Users"; 
            entity.Email = member.Email; 
            entity.ID_client = ++lastID; 
            _entities.Add(entity); 
        } 
        return lastID; 
    } 
