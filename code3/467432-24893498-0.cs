    public async static Task<List<ADUserEntity>> FindUsers(String searchString)
    {
    	searchString = String.Format("*{0}*", searchString);
    	List<ADUserEntity> users = new List<ADUserEntity>();
    
    	using (UserPrincipal searchMaskDisplayname = new UserPrincipal(domainContext) { DisplayName = searchString })
    	using (UserPrincipal searchMaskUsername = new UserPrincipal(domainContext) { SamAccountName = searchString })
    	using (PrincipalSearcher searcherDisplayname = new PrincipalSearcher(searchMaskDisplayname))
    	using (PrincipalSearcher searcherUsername = new PrincipalSearcher(searchMaskUsername))
    	using (Task<PrincipalSearchResult<Principal>> taskDisplayname = Task.Run<PrincipalSearchResult<Principal>>(() => searcherDisplayname.FindAll()))
    	using (Task<PrincipalSearchResult<Principal>> taskUsername = Task.Run<PrincipalSearchResult<Principal>>(() => searcherUsername.FindAll()))
    	{
    		foreach (UserPrincipal userPrincipal in (await taskDisplayname).Union(await taskUsername))
    			using (userPrincipal)
    			{
    				users.Add(new ADUserEntity(userPrincipal));
    			}
    	}
    
    	return users.Distinct().ToList();
    }
