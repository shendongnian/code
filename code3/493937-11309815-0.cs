		// define context for current domain
		using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
			// find  user 
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "YourNameHere");
			if (user != null)
			{
				// get groups the user is a member of
                var groups = current.GetGroups();
				// iterate over all those groups
                foreach(var group in groups)
                {
					// fetch the SID for each group
                    var sid = group.Sid;
                }
			}
		}	
			
