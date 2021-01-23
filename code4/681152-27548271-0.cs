    public bool IsMember(UserPrincipal user, string groupName)
    {
    
                try
                {
                    var context = new PrincipalContext(ContextType.Domain, Environment.UserDomainName);
                    var group = GroupPrincipal.FindByIdentity(context, groupName);
                    if (group == null)
                    {
                        //Not exist
                    }
                    else
                    {
                        if (group.GetMembers(true).Any(member => user.SamAccountName.ToLower() == member.SamAccountName.ToLower()))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception exception)
                {
                       //exception
                }
    
                return false;
        }
