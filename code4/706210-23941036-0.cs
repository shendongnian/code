    class ADGroupSearch
    {
        List<String> groupNames;
        public ADGroupSearch()
        {
            this.groupNames = new List<String>();
        }
        public List<String> GetGroups()
        {
            return this.groupNames;
        }
        public void AddGroupName(String groupName)
        {
            this.groupNames.Add(groupName);
        }
        public List<String> GetListOfGroupsRecursively(String samAcctName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, System.Environment.UserDomainName);
            Principal principal = Principal.FindByIdentity(ctx, IdentityType.SamAccountName, samAcctName);
            if (principal == null)
            {
                return GetGroups();
            }
            else
            {
                PrincipalSearchResult<Principal> searchResults = principal.GetGroups();
                
                if (searchResults != null)
                {
                    foreach (GroupPrincipal sr in searchResults)
                    {
                        if (!this.groupNames.Contains(sr.Name))
                        {
                            AddGroupName(sr.Name);
                        }
                        Principal p = Principal.FindByIdentity(ctx, IdentityType.SamAccountName, sr.SamAccountName);
                        
                        try
                        {
                            GetMembersForGroup(p);
                        }
                        catch (Exception ex)
                        {
                            //ignore errors and continue
                        }
                    }
                    
                }
                return GetGroups();
            }
        }
        
        private void GetMembersForGroup(Principal group)
        {
            if (group != null && typeof(GroupPrincipal) == group.GetType())
            {
                GetListOfGroupsRecursively(group.SamAccountName);
            } 
        }
        private bool IsGroup(Principal principal)
        {
            return principal.StructuralObjectClass.ToLower().Equals("group");
        }
    }
